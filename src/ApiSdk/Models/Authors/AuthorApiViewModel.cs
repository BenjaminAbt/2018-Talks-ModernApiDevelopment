using System;
using System.Collections.Generic;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books;

namespace BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors
{
    /// <summary>
    /// The return model that represents an author
    /// </summary>
    public class AuthorApiViewModel
    {
        /// <summary>
        /// Unique identifier as .NET Guid
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Author's name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Aauthor's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Author's age 
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Author's age 
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Author's books 
        /// </summary>
        public List<BookApiViewModel> Books { get; set; }
    }
}
