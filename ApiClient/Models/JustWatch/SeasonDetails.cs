using Newtonsoft.Json;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class SeasonDetails
    {
        [JsonProperty("jw_entity_id", NullValueHandling = NullValueHandling.Ignore)]
        public string JwEntityId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("full_path", NullValueHandling = NullValueHandling.Ignore)]
        public string FullPath { get; set; }

        [JsonProperty("full_paths", NullValueHandling = NullValueHandling.Ignore)]
        public FullPaths FullPaths { get; set; }

        [JsonProperty("poster", NullValueHandling = NullValueHandling.Ignore)]
        public string Poster { get; set; }

        [JsonProperty("backdrops", NullValueHandling = NullValueHandling.Ignore)]
        public List<Backdrop> Backdrops { get; set; }

        [JsonProperty("short_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortDescription { get; set; }

        [JsonProperty("original_release_year", NullValueHandling = NullValueHandling.Ignore)]
        public long? OriginalReleaseYear { get; set; }

        [JsonProperty("tmdb_popularity", NullValueHandling = NullValueHandling.Ignore)]
        public double? TmdbPopularity { get; set; }

        [JsonProperty("object_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectType { get; set; }

        [JsonProperty("original_title", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalTitle { get; set; }

        [JsonProperty("offers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Offer> Offers { get; set; }

        [JsonProperty("scoring", NullValueHandling = NullValueHandling.Ignore)]
        public List<Scoring> Scoring { get; set; }

        [JsonProperty("credits", NullValueHandling = NullValueHandling.Ignore)]
        public List<Credit> Credits { get; set; }

        [JsonProperty("external_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<ExternalId> ExternalIds { get; set; }

        [JsonProperty("genre_ids", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> GenreIds { get; set; }

        [JsonProperty("episodes")]
        public List<Episode> Episodes { get; set; }

        [JsonProperty("show_id")]
        public long ShowId { get; set; }

        [JsonProperty("show_title", NullValueHandling = NullValueHandling.Ignore)]
        public string ShowTitle { get; set; }

        [JsonProperty("season_number")]
        public int SeasonNumber { get; set; }
    }
}