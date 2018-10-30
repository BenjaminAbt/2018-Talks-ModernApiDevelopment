using GraphQL.Types;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Engine
{
    public class MyQuerySchema : Schema
    {
        public MyQuerySchema(IObjectGraphType graphQuerySchema)
        {
            Query = graphQuerySchema;
        }
    }
}