using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.Sonarr
{
    public class TvShow
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("alternateTitles", NullValueHandling = NullValueHandling.Ignore)]
        public List<AlternateTitle> AlternateTitles { get; set; }

        [JsonProperty("sortTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string SortTitle { get; set; }

        [JsonProperty("seasonCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? SeasonCount { get; set; }

        [JsonProperty("totalEpisodeCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalEpisodeCount { get; set; }

        [JsonProperty("episodeCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? EpisodeCount { get; set; }

        [JsonProperty("episodeFileCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? EpisodeFileCount { get; set; }

        [JsonProperty("sizeOnDisk", NullValueHandling = NullValueHandling.Ignore)]
        public long? SizeOnDisk { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("overview", NullValueHandling = NullValueHandling.Ignore)]
        public string Overview { get; set; }

        [JsonProperty("previousAiring", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PreviousAiring { get; set; }

        [JsonProperty("network", NullValueHandling = NullValueHandling.Ignore)]
        public string Network { get; set; }

        [JsonProperty("airTime", NullValueHandling = NullValueHandling.Ignore)]
        public string AirTime { get; set; }

        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public List<Image> Images { get; set; }

        [JsonProperty("seasons", NullValueHandling = NullValueHandling.Ignore)]
        public List<Season> Seasons { get; set; }

        [JsonProperty("year", NullValueHandling = NullValueHandling.Ignore)]
        public int? Year { get; set; }

        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        [JsonProperty("profileId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProfileId { get; set; }

        [JsonProperty("seasonFolder", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SeasonFolder { get; set; }

        [JsonProperty("monitored", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Monitored { get; set; }

        [JsonProperty("useSceneNumbering", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UseSceneNumbering { get; set; }

        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Runtime { get; set; }

        [JsonProperty("tvdbId", NullValueHandling = NullValueHandling.Ignore)]
        public long? TvdbId { get; set; }

        [JsonProperty("tvRageId", NullValueHandling = NullValueHandling.Ignore)]
        public long? TvRageId { get; set; }

        [JsonProperty("tvMazeId", NullValueHandling = NullValueHandling.Ignore)]
        public long? TvMazeId { get; set; }

        [JsonProperty("firstAired", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FirstAired { get; set; }

        [JsonProperty("lastInfoSync", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastInfoSync { get; set; }

        [JsonProperty("seriesType", NullValueHandling = NullValueHandling.Ignore)]
        public string SeriesType { get; set; }

        [JsonProperty("cleanTitle", NullValueHandling = NullValueHandling.Ignore)]
        public string CleanTitle { get; set; }

        [JsonProperty("imdbId", NullValueHandling = NullValueHandling.Ignore)]
        public string ImdbId { get; set; }

        [JsonProperty("titleSlug", NullValueHandling = NullValueHandling.Ignore)]
        public string TitleSlug { get; set; }

        [JsonProperty("certification", NullValueHandling = NullValueHandling.Ignore)]
        public string Certification { get; set; }

        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Genres { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Tags { get; set; }

        [JsonProperty("added", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Added { get; set; }

        [JsonProperty("ratings", NullValueHandling = NullValueHandling.Ignore)]
        public Ratings Ratings { get; set; }

        [JsonProperty("qualityProfileId", NullValueHandling = NullValueHandling.Ignore)]
        public long? QualityProfileId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nextAiring", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NextAiring { get; set; }
    }

    public class AlternateTitle
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("seasonNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? SeasonNumber { get; set; }

        [JsonProperty("sceneSeasonNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? SceneSeasonNumber { get; set; }
    }

    public class Image
    {
        [JsonProperty("coverType", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverType { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

    public class Ratings
    {
        [JsonProperty("votes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Votes { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public double? Value { get; set; }
    }

    public class Season
    {
        [JsonProperty("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonProperty("monitored")]
        public bool Monitored { get; set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; }
    }

    public class Statistics
    {
        [JsonProperty("episodeFileCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? EpisodeFileCount { get; set; }

        [JsonProperty("episodeCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? EpisodeCount { get; set; }

        [JsonProperty("totalEpisodeCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalEpisodeCount { get; set; }

        [JsonProperty("sizeOnDisk", NullValueHandling = NullValueHandling.Ignore)]
        public long? SizeOnDisk { get; set; }

        [JsonProperty("percentOfEpisodes", NullValueHandling = NullValueHandling.Ignore)]
        public long? PercentOfEpisodes { get; set; }

        [JsonProperty("previousAiring", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PreviousAiring { get; set; }

        [JsonProperty("nextAiring", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? NextAiring { get; set; }
    }
}