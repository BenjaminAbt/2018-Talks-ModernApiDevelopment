using System;

namespace BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books
{
    /// <summary>
    /// The return model that represents a book
    /// </summary>
    public class BookApiViewModel
    {
        /// <summary>
        /// Unique identifier as .NET Guid
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Book's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Book's price
        /// </summary>
        public double Price { get; set; }
    }
}