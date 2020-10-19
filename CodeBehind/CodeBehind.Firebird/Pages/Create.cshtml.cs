//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeBehind.Firebird.Models;
using Microsoft.Extensions.Logging;
using CodeBehind.Firebird.Repository;

namespace CodeBehind.Firebird.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public CLIENTE cliente { get; set; }

        private readonly IClienteRepository _rep;

        public string Mensagem { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }
        public IActionResult OnGet()
        {
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
                cliente.ID = Guid.NewGuid().ToString();
                _rep.Persistir(cliente);

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
