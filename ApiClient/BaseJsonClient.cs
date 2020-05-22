using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WatchCommander.ApiClient
{
    public class BaseJsonClient : BaseHttpClient
    {
        protected const string JsonMediaType = "application/json";

        private readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AdjustToUniversal},
            },
        };

        protected BaseJsonClient(string baseUrl) : base(baseUrl)
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));
        }

        protected async Task<T> Get<T>(string path)
        {
            var contents = await GetStringOnSuccess(path);

            return string.IsNullOrEmpty(contents) ? default : JsonConvert.DeserializeObject<T>(contents, JsonSettings);
        }

        protected async Task<T> Post<T>(string path, object postData = null)
        {
            HttpContent content = null;
            if (postData != null)
            {
                content = new StringContent(JsonConvert.SerializeObject(postData, Formatting.None, JsonSettings),
                    Encoding.UTF8, JsonMediaType);
            }

            try
            {
                var response = await _client.PostAsync(path, content);

                return response.IsSuccessStatusCode
                    ? JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync(), JsonSettings)
                    : default;
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }
    }
}