using System;
using System.Collections.Generic;
using System.Linq;

namespace WatchCommander.ApiClient.Models.JustWatch
{
    public class SearchParamBuilder
    {
        private readonly SearchParameters _parameters = new SearchParameters();

        private SearchParamBuilder() { }

        public static SearchParamBuilder Create()
        {
            return new SearchParamBuilder();
        }

        public SearchParameters Build()
        {
            return _parameters;
        }

        public SearchParamBuilder WithQuery(string query)
        {
            _parameters.Query = query;

            return this;
        }

        public SearchParamBuilder WithPageSize(int size)
        {
            _parameters.PageSize = size;

            return this;
        }

        public SearchParamBuilder WithProviders(IEnumerable<StreamingProvider> providers)
        {
            return WithProviders(providers.Select(p => p.ShortName).ToArray());
        }

        public SearchParamBuilder WithProviders(params string[] shortNames)
        {
            shortNames = shortNames.Select(n => n?.Trim()?.ToLowerInvariant())
                                   .Where(n => !string.IsNullOrEmpty(n)).ToArray();
            var invalidName = shortNames.FirstOrDefault(n => n.Length != 3);
            if (!string.IsNullOrEmpty(invalidName))
            {
                throw new ArgumentException(
                    $"Invalid provider name given ('{invalidName}'). Expecting exactly 3 characters.",
                    nameof(shortNames));
            }

            if (shortNames.Any())
            {
                _parameters.Providers ??= new List<string>();
                _parameters.Providers.AddRange(shortNames);
            }

            return this;
        }

        public SearchParamBuilder WithMonetizationTypes(params string[] types)
        {
            types = types.Select(n => n?.Trim()?.ToLowerInvariant())
                         .Where(n => !string.IsNullOrEmpty(n)).ToArray();

            if (types.Any())
            {
                _parameters.MonetizationTypes ??= new List<string>();
                _parameters.MonetizationTypes.AddRange(types);
            }

            return this;
        }

        public SearchParamBuilder WithContentTypes(params string[] types)
        {
            types = types.Select(n => n?.Trim()?.ToLowerInvariant())
                         .Where(n => !string.IsNullOrEmpty(n)).ToArray();

            if (types.Any())
            {
                _parameters.ContentTypes ??= new List<string>();
                _parameters.ContentTypes.AddRange(types);
            }

            return this;
        }

        public SearchParamBuilder WithReleaseYear(int year)
        {
            return WithReleaseYearBetween(year, year);
        }

        public SearchParamBuilder WithReleaseYearBetween(int? from = null, int? until = null)
        {
            if (from.HasValue && until.HasValue && from.Value > until.Value)
            {
                throw new ArgumentException("From year should be before or equal to Until year.", nameof(@from));
            }
            _parameters.ReleaseYearFrom = from;
            _parameters.ReleaseYearUntil = until;

            return this;
        }
    }
}