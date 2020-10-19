//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.SqlServer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBehind.SqlServer.Repository
{
    public interface IClienteRepository
    {
        Cliente Selecionar(string id);

        int Persistir(Cliente cliente);
        IEnumerable<Cliente> Listar();

        int Excluir(string id);

        int Atualizar(Cliente cliente);

    }

    public class ClienteRepository : IClienteRepository
    {

        private readonly Contexto _contexto;

        public ClienteRepository()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Cliente> Listar()
        {
            return _contexto.Set<Cliente>();
        }

        public int Persistir(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            return _contexto.SaveChanges();
        }

        public int Atualizar(Cliente cliente)
        {            
            _contexto.Update(cliente);
            return _contexto.SaveChanges();
        }

        public int Excluir(string id)
        {
            _contexto.Clientes.Remove(_contexto.Clientes.Find(id));
            return _contexto.SaveChanges();
        }

        public Cliente Selecionar(string id)
        {
            return _contexto.Set<Cliente>().FirstOrDefault(x => x.Id == id);
        }
    }
}
