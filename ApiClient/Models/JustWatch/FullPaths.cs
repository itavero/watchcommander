using Newtonsoft.Json;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class FullPaths
    {
        [JsonProperty("MOVIE_DETAIL_OVERVIEW", NullValueHandling = NullValueHandling.Ignore)]
        public string MovieDetailOverview { get; set; }

        [JsonProperty("SHOW_DETAIL_OVERVIEW", NullValueHandling = NullValueHandling.Ignore)]
        public string ShowDetailOverview { get; set; }

        [JsonProperty("SEASON_DETAIL_OVERVIEW", NullValueHandling = NullValueHandling.Ignore)]
        public string SeasonDetailOverview { get; set; }
    }
}