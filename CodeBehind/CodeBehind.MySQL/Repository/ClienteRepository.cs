//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Dapper;
using MySqlConnector;
using CodeBehind.MySQL.Models;
using System.Linq;

namespace CodeBehind.MySQL.Repository
{
    public interface IClienteRepository
    {
        Cliente Selecionar(string id);
        IEnumerable<Cliente> Listar();
        void Persistir(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(string id);

    }

    public class ClienteRepository : IClienteRepository
    {
        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("mysqldb"); } }

        public ClienteRepository(IConfiguration config)
        {
            _configuracoes = config;
        }

        public Cliente Selecionar(string id)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                return conexao.Query<Cliente>("SELECT Id, Nome FROM Cliente WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public IEnumerable<Cliente> Listar()
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                return conexao.Query<Cliente>("SELECT Id, Nome FROM Cliente");
            }
        }

        public void Persistir(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("INSERT INTO Cliente VALUES (@Id, @Nome)", new
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome
                });
            }
        }

        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("UPDATE Cliente SET Nome = @Nome WHERE Id = @Id", new
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome
                });
            }
        }

        public void Excluir(string id)
        {
            using (var conexao = new MySqlConnection(_conexao))
            {
                conexao.Execute("DELETE FROM Cliente WHERE Id = @Id", new
                {
                    Id = id
                });
            }
        }
    }
}
