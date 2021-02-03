using GraphQL.Types;
using GraphQueryLanguage.Demo.Models;

namespace GraphQueryLanguage.Demo.Types
{
    /// <summary>
    /// Tudo em GraphQL é um tipo,e, um tipo pode ser entendido como uma entidade em seu banco de dados (relacional ou não relacional). 
    /// Os tipos forma um schema, e, o GraphQL possui 2 tipos padrão: RootQuery e RootMutation.
    /// </summary>
    public class ClienteType : ObjectGraphType<Cliente>
    {
        public ClienteType()
        {
            Name = "Cliente";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id cliente");            
            Field(x => x.Nome).Description("Nome do usuário");
            Field(x => x.Telefone).Description("Telefone do cliente");
            Field(x => x.Documento).Description("Documento do cliente");
        }
    }
}
