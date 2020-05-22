using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class Offer
    {
        [JsonProperty("monetization_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MonetizationType { get; set; }

        [JsonProperty("provider_id")]
        public int ProviderId { get; set; }

        [JsonProperty("retail_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? RetailPrice { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("urls", NullValueHandling = NullValueHandling.Ignore)]
        public Urls Urls { get; set; }

        [JsonProperty("presentation_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PresentationType { get; set; }

        [JsonProperty("date_provider_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DateProviderId { get; set; }

        [JsonProperty("date_created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [JsonProperty("audio_languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AudioLanguages { get; set; }

        [JsonProperty("subtitle_languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SubtitleLanguages { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("element_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? ElementCount { get; set; }

        [JsonProperty("new_element_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? NewElementCount { get; set; }

        [JsonProperty("last_change_retail_price", NullValueHandling = NullValueHandling.Ignore)]
        public double? LastChangeRetailPrice { get; set; }

        [JsonProperty("last_change_difference", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastChangeDifference { get; set; }

        [JsonProperty("last_change_percent", NullValueHandling = NullValueHandling.Ignore)]
        public double? LastChangePercent { get; set; }

        [JsonProperty("last_change_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? LastChangeDate { get; set; }

        [JsonProperty("last_change_date_provider_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LastChangeDateProviderId { get; set; }
    }
}