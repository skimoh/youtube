//***CODE BEHIND - BY RODOLFO.FONSECA***//
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OData.Demo.Models;
using OData.Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace OData.Demo.Controller
{
    public class ClienteController : ODataController
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteRepository _rep;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            try
            {
                var resultado = _rep.Listar();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            try
            {
                var resultado = _rep.Selecionar(key);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [EnableQuery]
        public IActionResult Post([Microsoft.AspNetCore.Mvc.FromBody] Cliente cliente)
        {
            try
            {
                var resultado = _rep.Persistir(cliente);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [EnableQuery]
        public IActionResult Put(int key, [Microsoft.AspNetCore.Mvc.FromBody]  Cliente cliente)
        {
            try
            {
                cliente.Id = key;
                var resultado = _rep.Atualizar(cliente);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [EnableQuery]
        public IActionResult Delete(int key)
        {
            try
            {
                var resultado = _rep.Excluir(key);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
