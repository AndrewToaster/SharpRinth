using System;
using System.Threading.Tasks;
using SharpRinth.Enums;
using SharpRinth.Filtering;
using SharpRinth.Json;
using SharpRinth.Utility;

namespace SharpRinth.Builders
{
    public sealed class ModSearchRequestBuilder : BuilderBase<ModSearch>
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Query { get; set; }
        public SearchIndex Indexing { get; set; }
        public ISearchFilter Filter { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="ModSearchRequestBuilder" />
        /// </summary>
        /// <param name="client">The <see cref="ModrinthClient" /> to build with</param>
        public ModSearchRequestBuilder(ModrinthClient client) : base(client)
        {
            Limit = 10;
            Offset = 0;
            Query = string.Empty;
            Filter = null;
            Indexing = SearchIndex.Relevance;
        }

        /// <summary>
        /// Sets the <see cref="Limit"/> value
        /// </summary>
        /// <param name="limit">The search result limit</param>
        /// <returns>Current <see cref="ModSearchRequestBuilder"/></returns>
        public ModSearchRequestBuilder WithLimit(int limit)
        {
            Limit = limit;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Offset"/> value
        /// </summary>
        /// <param name="offset">The search result offset</param>
        /// <returns>Current <see cref="ModSearchRequestBuilder"/></returns>
        public ModSearchRequestBuilder WithOffset(int offset)
        {
            Offset = offset;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Filter"/> value
        /// </summary>
        /// <param name="filter">The filter for searching</param>
        /// <returns>Current <see cref="ModSearchRequestBuilder"/></returns>
        public ModSearchRequestBuilder WithFilter(ISearchFilter filter)
        {
            Filter = filter;
            return this;
        }

        /// <summary>
        /// Modifies the <see cref="Filter"/> value
        /// </summary>
        /// <param name="filterAction">The action which acts upon the <see cref="Filter"/></param>
        /// <returns>Current <see cref="ModSearchRequestBuilder"/></returns>
        public ModSearchRequestBuilder ModifyFilter<TFilter>(Action<TFilter> filterAction) where TFilter : ISearchFilter
        {
            try
            {
                filterAction.Invoke((TFilter)Filter);
            }
            catch (InvalidCastException)
            {
                System.Diagnostics.Debug.Fail("Caught cast error on " + nameof(ModifyFilter));
            }

            return this;
        }

        /// <summary>
        /// Modifies the <see cref="Filter"/> value
        /// </summary>
        /// <param name="filterAction">The action which acts upon the <see cref="Filter"/></param>
        /// <returns>Current <see cref="ModSearchRequestBuilder"/></returns>
        public ModSearchRequestBuilder ModifyFilter(Action<ISearchFilter> filterAction)
        {
            filterAction.Invoke(Filter);
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Indexing"/> value
        /// </summary>
        /// <param name="indexing">The search indexing</param>
        /// <returns>Current <see cref="ModSearchRequestBuilder"/></returns>
        public ModSearchRequestBuilder WithIndexing(SearchIndex indexing)
        {
            Indexing = indexing;
            return this;
        }

        /// <summary>
        /// Constructs and synchronously executes this <see cref="BuilderBase{T}" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override ExecuteResult<ModSearch> Execute()
        {
            return ExecuteAsync().Result;
        }

        /// <summary>
        /// Constructs and asynchronously executes this <see cref="BuilderBase{T}" />
        /// </summary>
        /// <returns>The builder result</returns>
        public override async Task<ExecuteResult<ModSearch>> ExecuteAsync()
        {
            string query = new QueryBuilder("mod")
                .AddQuery("limit", Limit)
                .AddQuery("offset", Offset)
                .AddQueryNonEmpty("query", Query)
                .AddQueryNonEmpty("filters", Filter?.ToString())
                .Build();

            var result = await client.TryGetDeserialized<ModSearch>(query, serializerOptions).ConfigureAwait(false);
            return new ExecuteResult<ModSearch>(result.result, result.success);
        }
    }
}
