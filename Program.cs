using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WatchCommander.ApiClient;
using WatchCommander.ApiClient.Models.Config;
using WatchCommander.ApiClient.Models.JustWatch;
using WatchCommander.ApiClient.Models.Radarr;
using WatchCommander.ApiClient.Models.Sonarr;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace WatchCommander
{
    internal class Program
    {
        private static Configuration _config;
        private static SortedSet<string> _deletedStuff;
        private static SortedSet<string> _failedStuff;

        private static async Task Main(string[] args)
        {
            // Load configuration
            var configFile = "watchcommander.yml";
            if (args.Any())
            {
                configFile = args[0].Trim();
            }

            if (!File.Exists(configFile))
            {
                await Console.Error.WriteLineAsync(
                    $"Config file ({configFile}) does not exist. See watchcommander.example.yml for an example.");

                return;
            }
            var yamlDeserializer = new DeserializerBuilder()
                                   .WithNamingConvention(UnderscoredNamingConvention.Instance)
                                   .Build();
            using (var reader = new StreamReader(configFile))
            {
                _config = yamlDeserializer.Deserialize<Configuration>(reader);
            }

            if (string.IsNullOrWhiteSpace(_config?.Country)
                || !_config.Providers.Any())
            {
                await Console.Error.WriteLineAsync("Please check your configuration. It seems to be invalid.");

                return;
            }

            Console.WriteLine("WatchCommander started.");

            var justWatch = new JustWatchClient();
            await justWatch.SetLocale(_config.Country);
            var providers = (await justWatch.GetProviders())
                            .Where(p => (p.MonetizationTypes?.Count ?? 0) == 0 ||
                                        p.MonetizationTypes.Contains("flatrate"))
                            .Where(p => _config.Providers.Any(s =>
                                s.Equals(p.ShortName, StringComparison.InvariantCultureIgnoreCase)))
                            .ToArray();

            _deletedStuff = new SortedSet<string>();
            _failedStuff = new SortedSet<string>();

            await CleanUpRadarr(providers, justWatch);
            await CleanUpSonarr(providers, justWatch);

            Console.WriteLine();
            if (_failedStuff.Any())
            {
                Console.Error.WriteLine("Failed to delete");
                foreach (var stuff in _failedStuff)
                {
                    Console.Error.WriteLine($"\t- {stuff}");
                }
            }

            if (_deletedStuff.Any())
            {
                Console.WriteLine("Deleted:");
                foreach (var stuff in _deletedStuff)
                {
                    Console.WriteLine($"\t- {stuff}");
                }
            }

            Console.WriteLine("End of clean-up.");
        }

        private static async Task CleanUpSonarr(StreamingProvider[] providers, JustWatchClient justWatch)
        {
            if (string.IsNullOrWhiteSpace(_config?.Sonarr?.Url) || string.IsNullOrWhiteSpace(_config?.Sonarr?.Key))
            {
                Console.WriteLine("Sonarr not configured.");

                return;
            }

            Console.WriteLine("Cleaning up Sonarr...");

            var sonarr = new SonarrClient(_config.Sonarr.Url, _config.Sonarr.Key);
            var shows = await sonarr.GetShows();
            foreach (var show in shows)
            {
                var jwShow = await SearchForTvShow(providers, justWatch, show);
                if (jwShow == null)
                {
                    continue;
                }

                // Get show details
                var details = await justWatch.GetShowDetails(jwShow.Id);

                var canAllBeStreamed = true;
                var streamableSeasons = new HashSet<int>();

                // Filter monitored seasons (or seasons with downloads)
                foreach (var season in show.Seasons.Where(s => s.Monitored || s.Statistics.EpisodeFileCount > 0))
                {
                    // Ignore if season number = 0; not a real season
                    if (season.SeasonNumber < 1)
                    {
                        continue;
                    }

                    var jwSeasonId = details.Seasons.Where(s => s.SeasonNumber == season.SeasonNumber)
                                            .Select(s => (long?) s.Id)
                                            .FirstOrDefault();
                    if (!jwSeasonId.HasValue)
                    {
                        canAllBeStreamed = false;

                        continue;
                    }

                    // Check streaming offers that offer the entire season
                    var seasonDetails = await justWatch.GetSeasonDetails(jwSeasonId.Value);
                    var availableOnProviders = seasonDetails.Offers?.Where(o =>
                                                                o.MonetizationType.Equals("flatrate",
                                                                    StringComparison.InvariantCultureIgnoreCase) &&
                                                                o.ElementCount >= seasonDetails.Episodes.Count)
                                                            .Select(o =>
                                                                providers.FirstOrDefault(p => p.Id == o.ProviderId))
                                                            .Where(p => p != null);

                    if (availableOnProviders?.Any() ?? false)
                    {
                        streamableSeasons.Add(season.SeasonNumber);
                    }
                    else
                    {
                        canAllBeStreamed = false;
                    }
                }

                var stuffTitle = $"TV Show: {show.Title}";
                if (canAllBeStreamed)
                {
                    // Clean up all
                    stuffTitle += "(all seasons)";
                    if (await sonarr.DeleteShow(show.Id, true))
                    {
                        _deletedStuff.Add(stuffTitle);
                    }
                    else
                    {
                        _failedStuff.Add(stuffTitle);
                    }
                }
                else if (streamableSeasons.Any())
                {
                    // Clean up only streamable seasons
                    _deletedStuff.Add($"{stuffTitle} ({string.Join(", ", streamableSeasons.Select(s => $"S{s}"))})");
                    // TODO: Use result of next call?
                    await sonarr.UnmonitorSeasons(show.Id, streamableSeasons);
                    var episodeFiles = await sonarr.GetEpisodeFiles(show.Id);
                    foreach (var file in episodeFiles.Where(f => streamableSeasons.Contains(f.SeasonNumber)))
                    {
                        try
                        {
                            await sonarr.DeleteEpisodeFile(file.Id);
                        }
                        catch
                        {
                            await Console.Error.WriteLineAsync(
                                $"Failed to delete episode file #{file.Id} ({show.Title} S{file.SeasonNumber})");
                        }
                    }
                }
            }
        }

        private static async Task<SearchResultItem> SearchForTvShow(StreamingProvider[] providers,
            JustWatchClient justWatch, TvShow show)
        {
            var showTitle = show.Title;
            if (show.Year.HasValue && show.Title.EndsWith($" ({show.Year.Value})"))
            {
                var yearSuffix = $" ({show.Year.Value})";
                showTitle = showTitle.Substring(0, showTitle.Length - yearSuffix.Length);
            }

            // Find show and details
            var jwShow = (await justWatch.Search(p =>
            {
                p.WithProviders(providers)
                 .WithQuery(showTitle)
                 .WithContentTypes("show")
                 .WithMonetizationTypes("flatrate")
                 .WithPageSize(5);
                if (show.Year.HasValue)
                {
                    p.WithReleaseYearBetween(from: show.Year.Value);
                }

                return p;
            })).Items.FirstOrDefault(i => i.Title.Equals(showTitle, StringComparison.InvariantCultureIgnoreCase));

            // TODO Maybe try alternative titles for show?
            return jwShow;
        }

        private static async Task CleanUpRadarr(StreamingProvider[] providers, JustWatchClient justWatch)
        {
            if (string.IsNullOrWhiteSpace(_config?.Radarr?.Url) || string.IsNullOrWhiteSpace(_config?.Radarr?.Key))
            {
                Console.WriteLine("Radarr not configured.");

                return;
            }

            Console.WriteLine("Cleaning up Radarr...");

            var radarr = new RadarrClient(_config.Radarr.Url, _config.Radarr.Key);

            var movies = await radarr.GetMovies();
            var today = DateTime.UtcNow;

            foreach (var movie in movies)
            {
                // Filter out the movies that actually make sense to check
                var isMonitored = movie.Monitored ?? true;
                var isDownloaded = movie.Downloaded ?? false;
                if (!isDownloaded)
                {
                    // Check cinema date
                    if (movie.InCinemas.HasValue)
                    {
                        if (movie.InCinemas.Value > today)
                        {
                            // No need to check; not yet in cinemas.
                            continue;
                        }
                    }

                    // Check physical release
                    if (movie.PhysicalRelease.HasValue)
                    {
                        if (movie.PhysicalRelease.Value > today)
                        {
                            // No need to check; not yet in released.
                            continue;
                        }
                    }

                    if (!isMonitored)
                    {
                        continue;
                    }
                }

                // Can we stream it?
                var streamProviders = await MovieCanBeStreamedOn(providers, justWatch, movie);

                if (streamProviders.Any())
                {
                    var stuffTitle = $"Movie: {movie.Title}";
                    if (await radarr.DeleteMovie(movie.Id, true))
                    {
                        _deletedStuff.Add(stuffTitle);
                    }
                    else
                    {
                        _failedStuff.Add(stuffTitle);
                    }
                }
            }
        }

        private static async Task<HashSet<StreamingProvider>> MovieCanBeStreamedOn(StreamingProvider[] providers,
            JustWatchClient justWatch, Movie movie)
        {
            var parameters = SearchParamBuilder.Create()
                                               .WithProviders(providers)
                                               .WithMonetizationTypes("flatrate")
                                               .WithContentTypes("movie")
                                               .WithPageSize(10)
                                               .WithQuery(movie.Title);
            if (movie.Year.HasValue)
            {
                parameters.WithReleaseYear(movie.Year.Value);
            }

            var results = await justWatch.Search(parameters);
            var tmdbId = movie.TmdbId?.ToString();
            foreach (var result in results.Items)
            {
                // Check if IDs match or title is exact match
                if (!result.Title.Equals(movie.Title, StringComparison.InvariantCultureIgnoreCase)
                    && !result.Scoring.Any(s =>
                        s.ProviderType.Equals("tmdb:id", StringComparison.InvariantCultureIgnoreCase) &&
                        s.Value.Equals(tmdbId, StringComparison.InvariantCultureIgnoreCase)))
                {
                    // not a match
                    continue;
                }

                return result.Offers.Where(o =>
                                 o.MonetizationType.Equals("flatrate", StringComparison.InvariantCultureIgnoreCase))
                             .Select(o => providers.FirstOrDefault(p => p.Id == o.ProviderId)).Where(p => p != null)
                             .ToHashSet();
            }

            return new HashSet<StreamingProvider>();
        }
    }
}