//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBehind.Sqlite.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
           : base(options)
        { }
    }
}
