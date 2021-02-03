//***CODE BEHIND - BY RODOLFO.FONSECA***//
using GraphQueryLanguage.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQueryLanguage.Demo.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
           : base(options)
        { }
    }
}
