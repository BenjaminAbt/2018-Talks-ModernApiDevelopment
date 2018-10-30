using System.Collections.Generic;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Collection media results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CollectionResult<T> : HypermediaResult
    {
        /// <summary>
        /// Items skipped
        /// </summary>
        public int Skip { get; }

        /// <summary>
        /// Items took
        /// </summary>
        public int Take { get; }

        /// <summary>
        /// Item total
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Item count
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Creates an instance of <see cref="CollectionResult&lt;T&gt;"/>
        /// </summary>
        /// <param name="items">Items to return</param>
        /// <param name="skip">Items skipped</param>
        /// <param name="take">Items took</param>
        /// <param name="total">Items total</param>
        public CollectionResult(IList<T> items, int skip, int take, int total)
        {
            Items = items;
            Skip = skip;
            Take = take;
            Total = total;
            Count = items?.Count ?? 0;
        }

        /// <summary>
        /// Items to return as collection
        /// </summary>
        public IList<T> Items { get; }
    }
}