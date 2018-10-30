using BenjaminAbt.ModernAPIDevelopment.Common.Models;
using GraphQL.Types;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Engine
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The id of the author.");
            Field(x => x.FirstName).Description("The first name of the author.");
            Field(x => x.LastName).Description("The last name of the author.");
            Field<ListGraphType<BookType>>("books", resolve: context => new Book[] { });
            Field(x => x.DateOfBirth).Description("The dob of the author.");
        }
    }
}