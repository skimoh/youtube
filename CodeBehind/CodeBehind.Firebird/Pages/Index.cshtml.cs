//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBehind.Firebird.Models;
using CodeBehind.Firebird.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.Firebird.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<CLIENTE> Clientes { get; set; }
        private readonly IClienteRepository _rep;


        public IndexModel(ILogger<IndexModel> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Clientes = _rep.Listar().ToList();

            return Page();
        }

    }
}
