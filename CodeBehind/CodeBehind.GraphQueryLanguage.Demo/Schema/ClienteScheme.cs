//***CODE BEHIND - BY RODOLFO.FONSECA***//
using GraphQL;
using GraphQL.Types;
using GraphQLCore.Demo.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQueryLanguage.Demo.Demo
{
    /// <summary>
    /// Descreve a funcionalidade disponível para os clientes que se conectam a ele.
    /// </summary>
    public class ClienteScheme : Schema
    {
        public ClienteScheme(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<ClienteQuery>();            

        }
    }
}

