namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Represents a single result
    /// </summary>
    /// <typeparam name="T">Type of return</typeparam>
    public class SingleResult<T> : HypermediaResult
    {
        /// <summary>
        /// Creates an instance of <see cref="SingleResult&lt;T&gt;"/>
        /// </summary>
        /// <param name="item">Item to return</param>
        public SingleResult(T item)
        {
            Item = item;
        }

        /// <summary>
        /// Item
        /// </summary>
        public T Item { get;  }
    }
}
