using System;
using System.Collections.Generic;
using System.Text;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities
{
    public class AuthorEntity: IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IList<BookEntity> Books { get; set; } = new List<BookEntity>();
    }
}
