//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeBehind.CosmoDB.Models;
using Microsoft.Extensions.Logging;
using CodeBehind.CosmoDB.Repository;

namespace CodeBehind.CosmoDB.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;
        public IEnumerable<Cliente> Clientes { get; set; }
        private readonly ICosmosDbService _rep;
        public string Mensagem { get; set; }
        public DeleteModel(ILogger<DeleteModel> logger, ICosmosDbService rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                _rep.ExcluirAsync(id);
                Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                Mensagem = "Falha";
            }
            return RedirectToPage("Index");
        }
    }
}
