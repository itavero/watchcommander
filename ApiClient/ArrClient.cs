using System;

namespace WatchCommander.ApiClient
{
    public abstract class ArrClient : BaseJsonClient
    {
        protected ArrClient(string baseUrl, string apiKey) : base(baseUrl)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("API Key required", nameof(apiKey));
            }
            _client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        }
    }
}