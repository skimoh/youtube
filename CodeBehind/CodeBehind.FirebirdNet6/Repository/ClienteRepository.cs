//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.FirebirdNet6.Models;

namespace CodeBehind.FirebirdNet6.Repository
{
    public interface IClienteRepository
    {
        Cliente Selecionar(string id);

        int Persistir(Cliente cliente);
        IEnumerable<Cliente> Listar();

        int Excluir(int id);

        int Atualizar(Cliente cliente);

    }

    public class ClienteRepository : IClienteRepository
    {

        private readonly Contexto _contexto;

        public ClienteRepository(Contexto contexto)
        {
            _contexto = contexto;
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

        public Cliente Selecionar(string id)
        {
            return _contexto.Set<Cliente>().FirstOrDefault(x => x.IdCliente == Convert.ToInt32(id));
        }
    }
}
