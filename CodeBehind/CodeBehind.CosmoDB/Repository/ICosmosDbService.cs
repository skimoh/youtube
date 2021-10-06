//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.CosmoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBehind.CosmoDB.Repository
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Cliente>> ListarAsync(string query);
        Task<Cliente> SelecionarAsync(string id);
        Task InserirAsync(Cliente item);
        Task AtualizarAsync(string id, Cliente item);
        Task ExcluirAsync(string id);
    }
}
