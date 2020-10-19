//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.SqlServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBehind.SqlServer.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE171;Database=sqldb;Trusted_Connection=True;");
            }
        }
    }
}
