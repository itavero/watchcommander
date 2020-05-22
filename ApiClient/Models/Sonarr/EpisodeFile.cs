using Newtonsoft.Json;

namespace WatchCommander.ApiClient.Models.Sonarr
{
    public class EpisodeFile
    {
        [JsonProperty("seriesId")]
        public int SeriesId { get; set; }

        [JsonProperty("seasonNumber")]
        public int SeasonNumber { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}