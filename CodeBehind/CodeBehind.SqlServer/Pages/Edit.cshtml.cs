//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeBehind.SqlServer.Models;
using CodeBehind.SqlServer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.SqlServer.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        [BindProperty]
        public Cliente cliente { get; set; }

        private readonly IClienteRepository _rep;

        public string Mensagem { get; set; }

        public EditModel(ILogger<EditModel> logger)
        {
            _logger = logger;
            _rep = new ClienteRepository();
        }

        public IActionResult OnGet(string id)
        {
            cliente = _rep.Selecionar(id);

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
                _rep.Atualizar(cliente);

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
