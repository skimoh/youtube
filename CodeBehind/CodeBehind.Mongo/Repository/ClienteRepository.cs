//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeBehind.Mongo.Repository
{

    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Listar();
        Task<Cliente> Selecionar(string id);

        Task Persistir(Cliente item);

        Task<bool> Excluir(string id);

        Task<bool> Atualizar(string id, Cliente item);
    }

    public class ClienteRepository : IClienteRepository
    {

        private readonly Contexto _context = null;
        public ClienteRepository(IOptions<Settings> settings)
        {
            _context = new Contexto(settings);
        }

        public async Task<bool> Atualizar(string id, Cliente item)
        {
            try
            {
                
                IMongoCollection<Cliente> clientes = _context.Clientes;

                Expression<Func<Cliente, bool>> filter = x => x.Id.Equals(id);

                Cliente cli = clientes.Find(filter).FirstOrDefault();

                if (cli != null)
                {
                    cli.Nome = item.Nome;
                    ReplaceOneResult result = clientes.ReplaceOne(filter, cli);

                    return result.IsAcknowledged  && result.ModifiedCount > 0;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Excluir(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Clientes.DeleteManyAsync(n => n.Id.Equals(id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
       
        public async Task Persistir(Cliente item)
        {

            await _context.Clientes.InsertOneAsync(item);

        }

        public async Task<IEnumerable<Cliente>> Listar()
        {
            try
            {
                return await _context.Clientes.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> Selecionar(string id)
        {
            try
            {
                return await _context.Clientes
                                .Find(doc => doc.Id == id)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
