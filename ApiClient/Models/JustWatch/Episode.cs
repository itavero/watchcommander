using Newtonsoft.Json;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class Episode
    {
        [JsonProperty("jw_entity_id", NullValueHandling = NullValueHandling.Ignore)]
        public string JwEntityId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("short_description", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortDescription { get; set; }

        [JsonProperty("object_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectType { get; set; }

        [JsonProperty("offers")]
        public List<Offer> Offers { get; set; }

        [JsonProperty("runtime", NullValueHandling = NullValueHandling.Ignore)]
        public long? Runtime { get; set; }

        [JsonProperty("episode_number")]
        public int EpisodeNumber { get; set; }

        [JsonProperty("season_number")]
        public int SeasonNumber { get; set; }
    }
}