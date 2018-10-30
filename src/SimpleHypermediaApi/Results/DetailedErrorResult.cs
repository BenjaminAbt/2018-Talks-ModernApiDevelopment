namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Error body with further information
    /// </summary>
    public class DetailedErrorResult<T> : ErrorResult, IDetailedErrorResult<T>
    {
        /// <summary>
        /// Error body with further information
        /// </summary>
        public T Body { get; }

        /// <summary>
        /// Body Type
        /// </summary>
        public string BodyType { get; }

        /// <summary>
        /// Detail error container
        /// </summary>
        /// <param name="body">Error body with further information</param>
        /// <param name="errorCode">Error Code</param>
        /// <param name="title">Error Title</param>
        /// <param name="error">Error Reason</param>
        public DetailedErrorResult(T body, int errorCode, string title, string error) : base(errorCode, title, error)
        {
            Body = body;
            BodyType = body.GetType().FullName;
        }
    }

}