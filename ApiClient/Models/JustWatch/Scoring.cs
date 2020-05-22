using Newtonsoft.Json;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class Scoring
    {
        [JsonProperty("provider_type")]
        public string ProviderType { get; set; }

        [JsonProperty("value")] 
        public string Value { get; set; }
    }
}