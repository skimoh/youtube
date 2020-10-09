//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.PostGreSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeBehind.PostGreSQL.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
           : base(options)
        { }
    }
}
