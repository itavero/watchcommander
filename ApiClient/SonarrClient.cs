using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WatchCommander.ApiClient.Models.Sonarr;

namespace WatchCommander.ApiClient
{
    public class SonarrClient : ArrClient
    {
        public SonarrClient(string baseUrl, string apiKey) : base(baseUrl, apiKey) { }

        public async Task<ICollection<TvShow>> GetShows()
        {
            return await Get<List<TvShow>>("series");
        }

        public async Task<ICollection<EpisodeFile>> GetEpisodeFiles(int showId)
        {
            return await Get<List<EpisodeFile>>($"episodefile?seriesId={showId}");
        }

        public async Task<ICollection<int>> UnmonitorSeasons(int showId, IEnumerable<int> seasonNumbers)
        {
            var path = $"series/{showId}";
            try
            {
                var rawJson = await GetStringOnSuccess(path);
                var obj = JObject.Parse(rawJson);

                var result = new HashSet<int>();

                var seasons = (JArray) obj["seasons"];
                foreach (var season in seasons.OfType<JObject>()
                                              .Where(s => seasonNumbers.Contains((int) s["seasonNumber"])))
                {
                    result.Add((int) season["seasonNumber"]);
                    season["monitored"] = false;
                }

                var putData = new StringContent(obj.ToString(),
                    Encoding.UTF8, JsonMediaType);

                var responseOnPut = await _client.PutAsync(path, putData);

                if (responseOnPut.IsSuccessStatusCode)
                {
                    return result;
                }
            }
            catch
            {
                // empty list returned below
            }

            return new List<int>();
        }

        public async Task<bool> DeleteShow(int id, bool deleteFiles = false)
        {
            var parameters = new Dictionary<string, string>
            {
                {"deleteFiles", deleteFiles.ToString()},
            };

            return await Delete($"series/{id}", parameters);
        }

        public async Task<bool> DeleteEpisodeFile(int id)
        {
            return await Delete($"episodefile/{id}");
        }
    }
}