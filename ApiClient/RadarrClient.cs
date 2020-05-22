using System.Collections.Generic;
using System.Threading.Tasks;
using WatchCommander.ApiClient.Models.Radarr;

namespace WatchCommander.ApiClient
{
    public class RadarrClient : ArrClient
    {
        public RadarrClient(string baseUrl, string apiKey) : base(baseUrl, apiKey) { }

        public async Task<ICollection<Movie>> GetMovies()
        {
            return await Get<List<Movie>>("movie");
        }

        public async Task<bool> DeleteMovie(int id, bool deleteFiles = false, bool addExclusion = false)
        {
            var parameters = new Dictionary<string, string>
            {
                {"deleteFiles", deleteFiles.ToString()},
                {"addExclusion", addExclusion.ToString()},
            };

            return await Delete($"movie/{id}", parameters);
        }
    }
}