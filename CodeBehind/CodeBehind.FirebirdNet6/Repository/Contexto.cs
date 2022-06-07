//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.FirebirdNet6.Models;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;

namespace CodeBehind.FirebirdNet6.Repository
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {          
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
