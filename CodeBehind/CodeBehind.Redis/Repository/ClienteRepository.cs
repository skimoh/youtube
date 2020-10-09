//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.Redis.Models;
using Microsoft.Extensions.Configuration;
using ServiceStack.Redis;
using System.Collections.Generic;

namespace CodeBehind.Redis.Repository
{
    /// <summary>
    /// Interface
    /// </summary>
    public interface IClienteRepository
    {
        int Excluir(string id);
        IEnumerable<Cliente> Listar();
        Cliente Selecionar(string id);
        int Persistir(Cliente cliente);
        int Atualizar(Cliente cliente);
    }

    /// <summary>
    /// https://docs.servicestack.net/netcore-redis
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        public string key = "id_c_";
        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("RedisServer"); } }
        private RedisManagerPool _pool;

        public ClienteRepository(IConfiguration config)
        {
            _configuracoes = config;
            _pool = new RedisManagerPool(_conexao);

        }

        /// <summary>
        /// FLUSHALL 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Excluir(string id)
        {
            using (var client = _pool.GetClient())
            {
                var obj = client.Remove(key + id);                
                return 1;
            }
        }

        /// <summary>
        ///  KEYS *
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cliente> Listar()
        {
            using (var client = _pool.GetClient())
            {
                var keys = client.GetAllKeys();

                var lista = new List<Cliente>();
                foreach (var key in keys)
                {
                    lista.Add(client.Get<Cliente>(key));
                }
                return lista;
            }
        }

        /// <summary>
        /// MGET key1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente Selecionar(string id)
        {
            using (var client = _pool.GetClient())
            {
                var obj = client.Get<Cliente>(key + id);                
                return obj;
            }
        }

        /// <summary>
        /// SET key1 "Hello"
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public int Persistir(Cliente cliente)
        {
            using (var client = _pool.GetClient())
            {
                client.Set<Cliente>(key + cliente.Id, cliente);
                return 1;
            }
        }
        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="cliente">Obj Cliente</param>
        /// <returns></returns>
        public int Atualizar(Cliente cliente)
        {
            using (var client = _pool.GetClient())
            {                
                client.Set<Cliente>(key + cliente.Id, cliente);
                return 1;
            }
        }

    }
}
