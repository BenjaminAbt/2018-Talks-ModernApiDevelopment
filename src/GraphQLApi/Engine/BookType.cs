using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using GraphQL.Types;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Engine
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The id of the book.");
            Field(x => x.Name).Description("The name of the book.");
            Field(x => x.Price).Description("The price of the book.");
        }
    }
}
