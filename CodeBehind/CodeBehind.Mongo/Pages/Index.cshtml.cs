using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBehind.Mongo.Models;
using CodeBehind.Mongo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.Mongo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Cliente> Clientes { get; set; }
        private readonly IClienteRepository _rep;


        public IndexModel(ILogger<IndexModel> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public async Task<IActionResult> OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Clientes = await _rep.Listar();

            return Page();
        }

    }
}
