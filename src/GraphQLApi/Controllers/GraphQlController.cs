using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace BenjaminAbt.ModernAPIDevelopment.GraphQLApi.Controllers
{

    [Route("graph")]
    public class GraphQlController : Controller
    {
        private readonly ISchema _schema;

        public GraphQlController(ISchema schema)
        {
            _schema = schema;
        }

        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            Inputs inputs = query.Variables.ToInputs();


            ExecutionResult result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                List<Exception> errors = new List<Exception>();
                foreach (ExecutionError error in result.Errors)
                {
                    Exception e = new Exception(error.Message);
                    if (error.InnerException != null)
                    {
                        e = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(e);
                }

                return BadRequest(errors);
            }

            return Ok(result);
        }
    }
}