using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class StreamingProvider
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("technical_name", NullValueHandling = NullValueHandling.Ignore)]
        public string TechnicalName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("clear_name")]
        public string ClearName { get; set; }

        [JsonProperty("monetization_types", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MonetizationTypes { get; set; }

        [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        protected bool Equals(StreamingProvider other)
        {
            return Id == other.Id && ShortName == other.ShortName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((StreamingProvider) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ShortName);
        }
    }
}