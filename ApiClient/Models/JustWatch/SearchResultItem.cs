using Newtonsoft.Json;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class SearchResultItem
    {
        [JsonProperty("jw_entity_id", NullValueHandling = NullValueHandling.Ignore)]
        public string JwEntityId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("full_path", NullValueHandling = NullValueHandling.Ignore)]
        public string FullPath { get; set; }

        [JsonProperty("full_paths", NullValueHandling = NullValueHandling.Ignore)]
        public FullPaths FullPaths { get; set; }

        [JsonProperty("poster", NullValueHandling = NullValueHandling.Ignore)]
        public string Poster { get; set; }

        [JsonProperty("original_release_year", NullValueHandling = NullValueHandling.Ignore)]
        public uint? OriginalReleaseYear { get; set; }

        [JsonProperty("tmdb_popularity", NullValueHandling = NullValueHandling.Ignore)]
        public double? TmdbPopularity { get; set; }

        [JsonProperty("object_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectType { get; set; }

        [JsonProperty("offers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Offer> Offers { get; set; }

        [JsonProperty("scoring", NullValueHandling = NullValueHandling.Ignore)]
        public List<Scoring> Scoring { get; set; }
    }
}