//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.ElasticSearch.Models;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodeBehind.ElasticSearch.Repository
{
    public interface IClienteRepository
    {
        bool Excluir(string id);
        IEnumerable<Cliente> Listar();
        Cliente Selecionar(string id);
        bool Persistir(Cliente cliente);
        bool Atualizar(Cliente cliente);
    }


    public class ClienteRepository : IClienteRepository
    {
        private readonly IElasticClient _elasticClient;

        public ClienteRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;

        }

        public bool Excluir(string id)
        {
            bool status;

            var response = _elasticClient.Delete<Cliente>(id, d => d
            .Index(nameof(Cliente).ToLower()));

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        public IEnumerable<Cliente> Listar()
        {
            var searchResponse = _elasticClient.Search<Cliente>(s => s
           .Index(nameof(Cliente).ToLower()));

            var people = searchResponse.Documents;
            return people?.ToList();
        }

        public Cliente Selecionar(string id)
        {
            var result = _elasticClient.Get<Cliente>(id);
           
            return result.Source;
        }

        public bool Persistir(Cliente cliente)
        {
            bool status;
            

            var response = _elasticClient.IndexDocument(cliente);

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        public bool Atualizar(Cliente cliente)
        {
            bool status;

            var response = _elasticClient.Update<Cliente, Cliente>(cliente.Id, d => d
            .Index(nameof(Cliente).ToLower())
            .Doc(cliente));

            if (response.IsValid)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

    }
}
