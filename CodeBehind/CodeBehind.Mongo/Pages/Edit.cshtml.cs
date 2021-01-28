using System;
using System.Threading.Tasks;
using CodeBehind.Mongo.Models;
using CodeBehind.Mongo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.IO;

namespace CodeBehind.Mongo.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        [BindProperty]
        public Cliente cliente { get; set; }

        private readonly IClienteRepository _rep;

        public string Mensagem { get; set; }

        public EditModel(ILogger<EditModel> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public async Task<IActionResult> OnGet(string id)
        {
            cliente = await _rep.Selecionar(id);

            return  Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _rep.Atualizar(cliente.Id, cliente);

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
