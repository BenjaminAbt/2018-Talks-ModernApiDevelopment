using System;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Authors;
using BenjaminAbt.ModernAPIDevelopment.Common.Engine.Queries.Books;
using GraphQL.Types;
using MediatR;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Engine
{
    public class MyGraphQuerySchema : ObjectGraphType
    {
        public MyGraphQuerySchema(IMediator mediator)
        {
            // Authors
            Field<AuthorType>("author",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    Guid id = context.GetArgument<Guid>("id");
                    return mediator.Send(new GetAuthorByIdQuery(id));
                });

            Field<ListGraphType<AuthorType>>("authors",
                resolve: context => mediator.Send(new GetAllAuthorsQuery()));

            // Books

            Field<BookType>("book",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "id" }),
                resolve: context =>
                {
                    Guid id = context.GetArgument<Guid>("id");
                    return mediator.Send(new GetBookByIdQuery(id));
                });

            Field<ListGraphType<BookType>>("books",
                resolve: context => mediator.Send(new GetAllBooksQuery()));
        }
    }
}