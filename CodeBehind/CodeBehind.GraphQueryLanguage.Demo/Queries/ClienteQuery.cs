//***CODE BEHIND - BY RODOLFO.FONSECA***//
using GraphQL;
using GraphQL.Types;
using GraphQueryLanguage.Demo.Models;
using GraphQueryLanguage.Demo.Repository;
using GraphQueryLanguage.Demo.Types;

namespace GraphQLCore.Demo.Queries
{
    /// <summary>
    /// O type Query serve para definir o contrato de consulta de dados
    /// </summary>
    public class ClienteQuery : ObjectGraphType<object>
    {
        public ClienteQuery(IClienteRepository repository)
        {
            //LISTAR TODOS
            Field<ListGraphType<ClienteType>>(
               "clientes",
               resolve: context => repository.Listar()
           );

            //SELECIONAR 1
            int id = 0;
            Field<ClienteType>(
                name: "cliente",
                arguments: new QueryArguments(new
                QueryArgument<IntGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    id = context.GetArgument<int>("id");
                    return repository.Selecionar(id);
                }
            );

            //EXCLUIR
            int idDelete = 0;
            Field<PostReturnType>(
                name: "cliente_excluir",
                arguments: new QueryArguments(new
                QueryArgument<IntGraphType>
                { Name = "id" }),
                resolve: context =>
                {
                    idDelete = context.GetArgument<int>("id");
                    return new PostReturn() { Status = repository.Excluir(idDelete) };
                }
            );

        }
    }

}

