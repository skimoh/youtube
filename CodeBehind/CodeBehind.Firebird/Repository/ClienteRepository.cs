//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.Firebird.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using Dapper;

namespace CodeBehind.Firebird.Repository
{
    public interface IClienteRepository
    {
        CLIENTE Selecionar(string id);

        int Persistir(CLIENTE cliente);
        IEnumerable<CLIENTE> Listar();

        int Excluir(string id);

        int Atualizar(CLIENTE cliente);

    }

    public class ClienteRepository : IClienteRepository
    {

        private IConfiguration _configuracoes;
        private string _conexao { get { return _configuracoes.GetConnectionString("firedb"); } }

        public ClienteRepository(IConfiguration config)
        {
            _configuracoes = config;
        }

        public IEnumerable<CLIENTE> Listar()
        {
            using (var conexao = new FbConnection(_conexao))
            {
                return conexao.Query<CLIENTE>("SELECT ID, NOME FROM CLIENTE");
            }
        }

        public int Persistir(CLIENTE cliente)
        {
            using (var conexao = new FbConnection(_conexao))
            {
                return conexao.Execute("INSERT INTO CLIENTE VALUES (@Id, @Nome)", new
                {
                    Id = cliente.ID,
                    Nome = cliente.NOME
                });
            }
        }

        public int Atualizar(CLIENTE cliente)
        {
            using (var conexao = new FbConnection(_conexao))
            {
                return conexao.Execute("UPDATE CLIENTE SET NOME = @Nome WHERE ID = @Id", new
                {
                    Id = cliente.ID,
                    Nome = cliente.NOME
                });
            }
        }

        public int Excluir(string id)
        {
            using (var conexao = new FbConnection(_conexao))
            {
                return conexao.Execute("DELETE FROM CLIENTE WHERE Id = @Id", new
                {
                    Id = id
                });
            }
        }

        public CLIENTE Selecionar(string id)
        {
            using (var conexao = new FbConnection(_conexao))
            {
                return conexao.Query<CLIENTE>("SELECT ID, NOME FROM CLIENTE WHERE ID = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}
