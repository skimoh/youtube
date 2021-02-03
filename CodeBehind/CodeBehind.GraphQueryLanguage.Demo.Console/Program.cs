//***CODE BEHIND - BY RODOLFO.FONSECA***//
using GraphQL.Types;
using GraphQL;
using GraphQL.Client.Http;
using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace GraphQueryLanguage.Demo.Invocar
{
    public class Program
    {        
        public static async Task Main(string[] args)
        {            

            //await LerTodos();
           // await LerUm();
            await Excluir();
        }

        private async static Task Excluir()
        {
            var req = new GraphQLRequest
            {
                Query = @"{cliente_excluir (id:13){ status }}",
                OperationName = null,
                Variables = null
            };

            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("http://localhost:49152/graphql/", UriKind.Absolute),
            };

            var client = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
            var graphQLResponse = await client.SendQueryAsync<dynamic>(req);

            Console.WriteLine(graphQLResponse.Data);
            Console.ReadKey();
        }

        private async static Task LerUm()
        {
            var req = new GraphQLRequest
            {
                Query = @"{cliente(id:13) {  id, nome }}",
                OperationName = null,
                Variables = null
            };

            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("http://localhost:49152/graphql/", UriKind.Absolute),
            };

            var client = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
            var graphQLResponse = await client.SendQueryAsync<dynamic>(req);

            Console.WriteLine(graphQLResponse.Data);
            Console.ReadKey();
        }

        private async static Task LerTodos()
        {
            var req = new GraphQLRequest
            {
                Query = @"{clientes {  id, nome }}",
                OperationName = null,
                Variables = null
            };

            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = new Uri("http://localhost:49152/graphql/", UriKind.Absolute),
            };

            var client = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
            var graphQLResponse = await client.SendQueryAsync<dynamic>(req);

            Console.WriteLine(graphQLResponse.Data);
            Console.ReadKey();
        }
    }

}
