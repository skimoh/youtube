//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.Maria.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeBehind.Maria.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public Contexto(DbContextOptions<Contexto> options)
         : base(options)
        {
        }
    }
}
