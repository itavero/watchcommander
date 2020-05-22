using Newtonsoft.Json;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class SearchParameters
    {
        [JsonProperty("age_certifications")]
        public List<string> AgeCertifications { get; set; }

        [JsonProperty("content_types")]
        public List<string> ContentTypes { get; set; }

        [JsonProperty("presentation_types")]
        public List<string> PresentationTypes { get; set; }

        [JsonProperty("providers")]
        public List<string> Providers { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        [JsonProperty("release_year_from")]
        public int? ReleaseYearFrom { get; set; }

        [JsonProperty("release_year_until")]
        public int? ReleaseYearUntil { get; set; }

        [JsonProperty("monetization_types")]
        public List<string> MonetizationTypes { get; set; }

        [JsonProperty("min_price")]
        public string MinPrice { get; set; }

        [JsonProperty("max_price")]
        public string MaxPrice { get; set; }

        [JsonProperty("nationwide_cinema_releases_only")]
        public string NationwideCinemaReleasesOnly { get; set; }

        [JsonProperty("scoring_filter_types")]
        public string ScoringFilterTypes { get; set; }

        [JsonProperty("cinema_release")]
        public string CinemaRelease { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("page_size")]
        public int? PageSize { get; set; }

        [JsonProperty("timeline_type")]
        public string TimelineType { get; set; }

        [JsonProperty("person_id")]
        public string PersonId { get; set; }
    }
}