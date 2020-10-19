//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.Maria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBehind.Maria.Repository
{
    public interface IClienteRepository
    {
       int Excluir(string id);
       IEnumerable<Cliente> Listar();
       Cliente Selecionar(string id);
       int Persistir(Cliente cliente);
       int Atualizar(Cliente cliente);
    }


    public class ClienteRepository : IClienteRepository
    {
        private readonly Contexto _dbContext;

        public ClienteRepository(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public int Excluir(string id)
        {
            try
            {
                var cliente = _dbContext.Clientes.Find(id);
                _dbContext.Clientes.Remove(cliente);

                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public  IEnumerable<Cliente> Listar()
        {
            return  _dbContext.Clientes.ToList();
        }

        public Cliente Selecionar(string id)
        {
            return _dbContext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public int Persistir(Cliente cliente)
        {
            _dbContext.Add(cliente);
            return  _dbContext.SaveChanges();
        }

        public int Atualizar(Cliente cliente)
        {
            try
            {
                _dbContext.Update(cliente);
                return _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

    }
}
