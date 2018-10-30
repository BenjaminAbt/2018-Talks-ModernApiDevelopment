using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books
{
    public class BookAddModel : IValidatableObject
    {
        public string Name { get; set; }
        public double? Price { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Name)) yield return new ValidationResult($"{nameof(Name)} is missing.", new[] { nameof(Name) });
            if (Price == null)
            {
                yield return new ValidationResult($"{nameof(Price)} is missing.", new[] { nameof(Price) });
            }
            else if (Price < 0)
            {
                yield return new ValidationResult($"{nameof(Price)} must be higher than 0.", new[] { nameof(Price) });
            }
        }
    }
}