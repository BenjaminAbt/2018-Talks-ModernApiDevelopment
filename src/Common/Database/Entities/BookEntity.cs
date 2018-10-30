using System;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Database.Entities
{
    public class BookEntity : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
    }
}