namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Contract for hypermedia results
    /// </summary>
    public interface IHypermediaResult
    {
        /// <summary>
        /// Returns the object serialized as json
        /// </summary>
        /// <returns></returns>
        string ToJson();
    }
}