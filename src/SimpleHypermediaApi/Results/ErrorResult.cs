namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Error Result
    /// </summary>
    public class ErrorResult : HypermediaResult, IErrorResult
    {
        /// <summary>
        /// Error Code
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Error Title
        /// </summary>
        public string ErrorTitle { get; }

        /// <summary>
        /// Error Reason
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Creates an instance of <see cref="ErrorResult"/>
        /// </summary>
        /// <param name="errorCode">Error Code</param>
        /// <param name="title">Error Title</param>
        /// <param name="error">Error Reason</param>
        public ErrorResult(int errorCode, string title, string error)
        {
            ErrorCode = errorCode;
            ErrorTitle = title;
            Error = error;
        }
    }
}
