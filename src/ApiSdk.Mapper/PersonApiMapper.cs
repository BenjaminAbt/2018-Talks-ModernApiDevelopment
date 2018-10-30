using System;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models;
using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;

namespace BenjaminAbt.ModernAPIDevelopment.ApiSdk.Mapper
{
    public static class AuthorApiMapper
    {
        public static AuthorApiViewModel MapToApiModel(Author source)
        {
            return new AuthorApiViewModel
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                DateOfBirth = source.DateOfBirth,

                Age = new DateTime(DateTime.Now.Subtract(source.DateOfBirth).Ticks).Year - 1,
            };
        }
    }
}