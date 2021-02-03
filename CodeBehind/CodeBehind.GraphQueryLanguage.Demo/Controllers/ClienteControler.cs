//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System.Threading.Tasks;
using GraphQL;
using GraphQueryLanguage.Demo.Demo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GraphQueryLanguage.Demo.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class ClienteControler : ControllerBase
    {

        private readonly ILogger<ClienteControler> _logger;
        private readonly ClienteScheme _schema; 

        public ClienteControler(ILogger<ClienteControler> logger, ClienteScheme schema)
        {
            _logger = logger;
            _schema = schema;            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryDTO query)
        {            
            var schema = _schema;

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = (Inputs)query.Variables; ;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
