using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WatchCommander.ApiClient.Models.JustWatch;

namespace WatchCommander.ApiClient
{
    public class JustWatchClient : BaseJsonClient
    {
        private Locale _locale;

        public JustWatchClient() : base("https://apis.justwatch.com/content/") { }

        private void CheckIfLocaleSet()
        {
            if (_locale == null)
            {
                throw new ApplicationException("No locale set.");
            }
        }

        public async Task<List<StreamingProvider>> GetProviders()
        {
            CheckIfLocaleSet();

            return await Get<List<StreamingProvider>>($"providers/locale/{_locale.FullLocale}");
        }

        public async Task<ShowTitleDetails> GetShowDetails(long id)
        {
            CheckIfLocaleSet();

            return await Get<ShowTitleDetails>($"titles/show/{id}/locale/{_locale.FullLocale}");
        }

        public async Task<SeasonDetails> GetSeasonDetails(long seasonId)
        {
            CheckIfLocaleSet();

            return await Get<SeasonDetails>($"titles/show_season/{seasonId}/locale/{_locale.FullLocale}");
        }

        public async Task<ICollection<Locale>> GetAvailableLocales()
        {
            return await Get<List<Locale>>("locales/state");
        }

        public void SetLocale(Locale locale)
        {
            _locale = locale;
        }

        public async Task SetLocale(string countryCode)
        {
            var locales = await GetAvailableLocales();
            var wanted = locales.FirstOrDefault(l =>
                countryCode.Equals(l.Iso3166_2, StringComparison.InvariantCultureIgnoreCase));
            if (wanted == null)
            {
                throw new ArgumentException("Unrecognized country", nameof(countryCode));
            }

            SetLocale(wanted);
        }

        public async Task<SearchResults> Search(Func<SearchParamBuilder, SearchParamBuilder> paramBuilder)
        {
            CheckIfLocaleSet();

            return await Search(paramBuilder(SearchParamBuilder.Create()).Build());
        }

        public async Task<SearchResults> Search(SearchParamBuilder paramBuilder)
        {
            CheckIfLocaleSet();

            return await Search(paramBuilder.Build());
        }

        protected async Task<SearchResults> Search(SearchParameters parameters)
        {
            var path = $"titles/{_locale.FullLocale}/popular";

            return await Post<SearchResults>(path, parameters);
        }

        public SearchResultsAsync SearchAll(Func<SearchParamBuilder, SearchParamBuilder> paramBuilder,
            int pageSize = 20)
        {
            CheckIfLocaleSet();

            return SearchAll(paramBuilder(SearchParamBuilder.Create()).Build(), pageSize);
        }

        public SearchResultsAsync SearchAll(SearchParameters parameters, int pageSize = 20)
        {
            CheckIfLocaleSet();

            return new SearchResultsAsync(this, parameters, pageSize);
        }

        public class SearchResultsAsync : IAsyncEnumerable<SearchResultItem>
        {
            private readonly JustWatchClient _client;
            private readonly int _pageSize;
            private readonly SearchParameters _parameters;

            internal SearchResultsAsync(JustWatchClient client, SearchParameters parameters, int pageSize)
            {
                _client = client;
                _parameters = parameters;
                _pageSize = pageSize;
            }

            public IAsyncEnumerator<SearchResultItem> GetAsyncEnumerator(
                CancellationToken cancellationToken = new CancellationToken())
            {
                return new SearchResultsAsyncEnumerator(_client, _parameters, _pageSize);
            }
        }

        private class SearchResultsAsyncEnumerator : IAsyncEnumerator<SearchResultItem>
        {
            private readonly JustWatchClient _client;
            private readonly int _pageSize;
            private readonly SearchParameters _parameters;
            private int _currentIndex;
            private SearchResults _currentResults;

            public SearchResultsAsyncEnumerator(JustWatchClient client, SearchParameters parameters, int pageSize)
            {
                _client = client;
                _parameters = parameters;
                _pageSize = pageSize;
                _currentIndex = 0;
                _currentResults = null;
            }

            public ValueTask DisposeAsync()
            {
                // Nothing to do?
                return new ValueTask();
            }

            public async ValueTask<bool> MoveNextAsync()
            {
                if (_currentResults == null)
                {
                    // Request first page
                    _parameters.Page = 1;
                    _parameters.PageSize = _pageSize;

                    _currentIndex = 0;
                    _currentResults = await _client.Search(_parameters);
                }
                else
                {
                    // Increment index;
                    ++_currentIndex;

                    // End of page reached?
                    var itemCount = _currentResults.Items?.Count ?? 0;
                    if (itemCount <= _currentIndex)
                    {
                        if (_currentResults.TotalPages.HasValue && _parameters.Page.HasValue &&
                            _currentResults.TotalPages.Value > _parameters.Page.Value)
                        {
                            ++_parameters.Page;
                            _currentIndex = 0;
                            _currentResults = await _client.Search(_parameters);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                return _currentResults?.Items != null && _currentResults.Items.Any();
            }

            public SearchResultItem Current
            {
                get
                {
                    if (_currentResults != null && _currentIndex < _currentResults.Items.Count)
                    {
                        return _currentResults.Items[_currentIndex];
                    }

                    return null;
                }
            }
        }
    }
}