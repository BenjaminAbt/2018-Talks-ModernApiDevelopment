using System.Collections.Generic;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Error Result
    /// </summary>
    public class ErrorsResult: HypermediaResult
    {
        /// <summary>
        /// Error Code
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Error Reason
        /// </summary>
        public IList<string> Errors { get; }

        /// <summary>
        /// Creates an instance of <see cref="ErrorsResult"/>
        /// </summary>
        /// <param name="errorCode">Error Code</param>
        /// <param name="errors">Error Reason</param>
        public ErrorsResult(int errorCode, IList<string> errors)
        {
            ErrorCode = errorCode;
            Errors = errors;
        }
    }
}
