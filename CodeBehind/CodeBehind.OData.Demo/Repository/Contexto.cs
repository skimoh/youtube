//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Microsoft.EntityFrameworkCore;
using OData.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OData.Demo.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options)
           : base(options)
        { }
    }
}
