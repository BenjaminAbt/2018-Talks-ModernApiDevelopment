using Newtonsoft.Json;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Results
{
    /// <summary>
    /// Base for hypermedia results
    /// </summary>
    public abstract class HypermediaResult : IHypermediaResult
    {
        /// <summary>
        /// returns the instance as json
        /// </summary>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}