using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors
{
    public class AuthorAddModel : IValidatableObject
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (String.IsNullOrEmpty(Name)) yield return new ValidationResult($"{nameof(Name)} is missing.", new[] { nameof(Name) });
            if (String.IsNullOrEmpty(LastName)) yield return new ValidationResult($"{nameof(LastName)} is missing.", new[] { nameof(LastName) });
        }
    }
}