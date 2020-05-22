using Newtonsoft.Json;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class SearchResults
    {
        [JsonProperty("total_results")]
        public uint? TotalResults { get; set; }

        [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
        public uint? Page { get; set; }

        [JsonProperty("page_size", NullValueHandling = NullValueHandling.Ignore)]
        public uint? PageSize { get; set; }

        [JsonProperty("total_pages", NullValueHandling = NullValueHandling.Ignore)]
        public uint? TotalPages { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<SearchResultItem> Items { get; set; }
    }
}