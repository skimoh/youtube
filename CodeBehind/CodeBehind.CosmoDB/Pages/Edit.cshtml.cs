//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using CodeBehind.CosmoDB.Repository;
using CodeBehind.CosmoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.CosmoDB.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        [BindProperty]
        public Cliente cliente { get; set; }

        private readonly ICosmosDbService _rep;

        public string Mensagem { get; set; }

        public EditModel(ILogger<EditModel> logger, ICosmosDbService rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGet(string id)
        {
            cliente =  _rep.SelecionarAsync(id).GetAwaiter().GetResult();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _rep.AtualizarAsync(cliente.IdCliente, cliente).GetAwaiter().GetResult();

                Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                Mensagem = ex.Message;
            }
            return Page();
        }
    }
}
