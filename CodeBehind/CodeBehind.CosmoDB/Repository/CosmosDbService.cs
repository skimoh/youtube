//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.CosmoDB.Models;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBehind.CosmoDB.Repository
{
    public class CosmosDbService : ICosmosDbService
    {
        private Container _container;

        public CosmosDbService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task InserirAsync(Cliente item)
        {
            await this._container.CreateItemAsync<Cliente>(item, new PartitionKey(item.IdCliente));
        }

        public async Task ExcluirAsync(string id)
        {
            await this._container.DeleteItemAsync<Cliente>(id, new PartitionKey(id));
        }

        public async Task<Cliente> SelecionarAsync(string id)
        {
            try
            {
                ItemResponse<Cliente> response = await this._container.ReadItemAsync<Cliente>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<Cliente>> ListarAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Cliente>(new QueryDefinition(queryString));
            List<Cliente> results = new List<Cliente>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task AtualizarAsync(string id, Cliente item)
        {
            await this._container.UpsertItemAsync<Cliente>(item, new PartitionKey(id));
        }
    }
}
