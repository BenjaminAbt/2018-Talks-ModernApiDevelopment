using System;
using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.Common.Engine.Commands.Books
{
    public class AddBookCommand : IRequest<Book>
    {
        public string Name { get; }
        public double Price { get; }

        public AddBookCommand(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}