//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CodeBehind.SqlServer.Models;
using Microsoft.Extensions.Logging;
using CodeBehind.SqlServer.Repository;

namespace CodeBehind.SqlServer.Pages
{
    public class CreateModel : PageModel, IDisposable
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Cliente cliente { get; set; }

        private IClienteRepository _rep;

        public string Mensagem { get; set; }

        public CreateModel(ILogger<CreateModel> logger)
        {
            _logger = logger;
            _rep = new ClienteRepository();
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
                cliente.Id = Guid.NewGuid().ToString();
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

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _rep = null;
                }
                disposed = true;
            }
        }

        public void Dispose()
        { 
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
