using System;
using System.Collections.Generic;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Models
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<Book> Books { get; set; }
    }
}
