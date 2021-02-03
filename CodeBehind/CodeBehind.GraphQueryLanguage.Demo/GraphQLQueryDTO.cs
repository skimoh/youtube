//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Newtonsoft.Json.Linq;

namespace GraphQueryLanguage.Demo
{
    public class GraphQLQueryDTO
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public object Variables { get; set; }
    }
}
