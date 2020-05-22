using Newtonsoft.Json;

namespace WatchCommander.ApiClient.Models.Radarr
{
    public class DeleteRequest
    {
        [JsonProperty("deleteFiles")]
        public bool DeleteFiles { get; set; }
    }
}