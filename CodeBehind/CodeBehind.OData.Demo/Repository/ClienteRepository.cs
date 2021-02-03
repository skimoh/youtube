//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Microsoft.Extensions.Configuration;
using OData.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OData.Demo.Repository
{
    public interface IClienteRepository
    {
        Cliente Selecionar(int id);

        int Persistir(Cliente cliente);
        IEnumerable<Cliente> Listar();

        int Excluir(int id);

        int Atualizar(Cliente cliente);

    }

    public class ClienteRepository : IClienteRepository
    {

        private readonly Contexto _contexto;

        public ClienteRepository(Contexto contexto_)
        {
            _contexto = contexto_;
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

        public int Excluir(int id)
        {
            _contexto.Clientes.Remove(_contexto.Clientes.Find(id));
            return _contexto.SaveChanges();
        }

        public Cliente Selecionar(int id)
        {
            return _contexto.Set<Cliente>().FirstOrDefault(x => x.Id == id);
        }
    }
}
