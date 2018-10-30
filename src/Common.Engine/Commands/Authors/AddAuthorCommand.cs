using System;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Commands.Authors
{
    public class AddAuthorCommand : IRequest<Author>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateofBirth { get; }

        public AddAuthorCommand(string firstName, string lastName, DateTime dateofBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateofBirth = dateofBirth;
        }
    }
}