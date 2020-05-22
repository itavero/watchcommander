namespace WatchCommander.ApiClient.Models.Config
{
    public class Configuration
    {
        public string Country { get; set; }
        public string[] Providers { get; set; }
        public ApiConfig Sonarr { get; set; }
        public ApiConfig Radarr { get; set; }
    }
}