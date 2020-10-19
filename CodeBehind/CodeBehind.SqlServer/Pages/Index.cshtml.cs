//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBehind.SqlServer.Models;
using CodeBehind.SqlServer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.SqlServer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Cliente> Clientes { get; set; }
        private readonly IClienteRepository _rep;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _rep = new ClienteRepository();
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Clientes = _rep.Listar();

            return Page();
        }

    }
}
