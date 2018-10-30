namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Error body with further information
    /// </summary>
    public interface IDetailedErrorResult : IErrorResult
    {
        /// <summary>
        /// Body Type
        /// </summary>
        string BodyType { get; }
    }

    /// <summary>
    /// Error body with further information
    /// </summary>
    public interface IDetailedErrorResult<out T> : IDetailedErrorResult
    {
        /// <summary>
        /// Error body with further information
        /// </summary>
        T Body { get; }
    }
}