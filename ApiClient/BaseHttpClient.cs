using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace WatchCommander.ApiClient
{
    public abstract class BaseHttpClient
    {
        protected readonly HttpClient _client = new HttpClient();

        protected BaseHttpClient(string baseUrl)
        {
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Add("User-Agent",
                $"{Assembly.GetExecutingAssembly().GetName().Name.Replace(" ", ".")}.v{Assembly.GetExecutingAssembly().GetName().Version}");
        }

        protected async Task<string> GetStringOnSuccess(string path)
        {
            try
            {
                var response = await _client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException)
            {
                //just return null below
            }

            // Do not return value if error occured
            return null;
        }

        protected async Task<bool> Delete(string path, Dictionary<string, string> parameters = null)
        {
            if (parameters?.Any() ?? false)
            {
                path += "?" + string.Join("&",
                    parameters.Select(kvp =>
                        $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));
            }

            try
            {
                var response = await _client.DeleteAsync(path);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }
    }
}