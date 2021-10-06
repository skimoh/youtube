//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBehind.CosmoDB.Repository;
using CodeBehind.CosmoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.CosmoDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Cliente> Clientes { get; set; }
        private readonly ICosmosDbService _rep;


        public IndexModel(ILogger<IndexModel> logger, ICosmosDbService rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Clientes = _rep.ListarAsync("SELECT * FROM c").GetAwaiter().GetResult();

            return Page();
        }

    }
}
