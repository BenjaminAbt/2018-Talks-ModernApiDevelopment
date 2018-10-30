namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Error Result
    /// </summary>
    public interface IErrorResult : IHypermediaResult
    {
        /// <summary>
        /// Error Code
        /// </summary>
        int ErrorCode { get; }

        /// <summary>
        /// Error Title
        /// </summary>
        string ErrorTitle { get; }

        /// <summary>
        /// Error Reason
        /// </summary>
        string Error { get; }
    }
}