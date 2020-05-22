using Newtonsoft.Json;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class Locale
    {
        [JsonProperty("exposed_url_part", NullValueHandling = NullValueHandling.Ignore)]
        public string ExposedUrlPart { get; set; }

        [JsonProperty("full_locale", NullValueHandling = NullValueHandling.Ignore)]
        public string FullLocale { get; set; }

        [JsonProperty("i18n_state", NullValueHandling = NullValueHandling.Ignore)]
        public string I18NState { get; set; }

        [JsonProperty("iso_3166_2", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso3166_2 { get; set; }

        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }
    }
}