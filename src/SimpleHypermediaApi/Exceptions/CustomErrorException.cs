using System;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Exceptions
{
    public class CustomErrorException : Exception
    {
        public CustomErrorException()
        {
            Timestamp = DateTime.UtcNow;
        }
        public DateTime Timestamp { get; set; }
    }
}