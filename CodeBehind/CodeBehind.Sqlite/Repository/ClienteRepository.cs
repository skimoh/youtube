using CodeBehind.Sqlite.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeBehind.Sqlite.Repository
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
            _contexto.Entry(_contexto.Clientes.FirstOrDefault(x => x.Id == cliente.Id)).CurrentValues.SetValues(cliente);            
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
