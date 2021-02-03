//***CODE BEHIND - BY RODOLFO.FONSECA***//
using GraphQueryLanguage.Demo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQueryLanguage.Demo.Repository
{
    public interface IClienteRepository
    {
        List<Cliente> Listar();
        Cliente Selecionar(int id);
        int Excluir(int id);
    }

    public class ClienteRepository : IClienteRepository
    {

        private readonly Contexto _contexto;

        public ClienteRepository(Contexto contexto_)
        {
            _contexto = contexto_;
        }

        public int Excluir(int id)
        {
            _contexto.Remove(_contexto.Clientes.Find(id));
            return _contexto.SaveChanges();
        }

        public List<Cliente> Listar() => _contexto.Clientes.AsTracking().ToList();

        public Cliente Selecionar(int id) => _contexto.Clientes.FirstOrDefault(p => p.Id == id);
    }
}
