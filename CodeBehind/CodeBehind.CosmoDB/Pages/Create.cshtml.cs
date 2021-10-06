//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeBehind.CosmoDB.Models;
using Microsoft.Extensions.Logging;
using CodeBehind.CosmoDB.Repository;

namespace CodeBehind.CosmoDB.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Cliente cliente { get; set; }

        private readonly ICosmosDbService _rep;

        public string Mensagem { get; set; }

        public CreateModel(ILogger<CreateModel> logger, ICosmosDbService rep)
        {
            _logger = logger;
            _rep = rep;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
      
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                cliente.IdCliente = Guid.NewGuid().ToString();
                cliente.Id = cliente.IdCliente;
                _rep.InserirAsync(cliente).GetAwaiter().GetResult();

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
