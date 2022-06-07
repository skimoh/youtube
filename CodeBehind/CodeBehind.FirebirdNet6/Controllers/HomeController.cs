//***CODE BEHIND - BY RODOLFO.FONSECA***//
using CodeBehind.FirebirdNet6.Models;
using CodeBehind.FirebirdNet6.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeBehind.FirebirdNet6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteRepository _rep;

        public HomeController(ILogger<HomeController> logger, IClienteRepository rep )
        {
            _logger = logger;
            _rep=rep;
        }

        public IActionResult Index()
        {
            var clientes = _rep.Listar();

            return View(clientes);
        }

        public IActionResult Edit(string id)
        {
            var cliente = _rep.Selecionar(id);

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                _rep.Atualizar(cliente);

                ViewBag.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                ViewBag.Mensagem = ex.Message;
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {                
                _rep.Persistir(cliente);

                ViewBag.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                ViewBag.Mensagem = ex.Message;
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                _rep.Excluir(id);
                ViewBag.Mensagem = "Sucesso";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                ViewBag.Mensagem = "Falha";
            }
            return RedirectToAction("Index","Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}