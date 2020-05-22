using Newtonsoft.Json;
using System;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class Urls
    {
        [JsonProperty("standard_web", NullValueHandling = NullValueHandling.Ignore)]
        public Uri StandardWeb { get; set; }

        [JsonProperty("deeplink_android_tv", NullValueHandling = NullValueHandling.Ignore)]
        public string DeeplinkAndroidTv { get; set; }

        [JsonProperty("deeplink_fire_tv", NullValueHandling = NullValueHandling.Ignore)]
        public string DeeplinkFireTv { get; set; }

        [JsonProperty("deeplink_tvos", NullValueHandling = NullValueHandling.Ignore)]
        public string DeeplinkTvos { get; set; }
    }
}