using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Softplan.CalculaJuros.Api.Core.Interfaces;
using Softplan.CalculaJuros.Api.Model;

namespace Softplan.CalculaJuros.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : Controller
    {
        private readonly ICalculadoraJuros _calculadoraJuros;

        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ICalculadoraJuros calculadoraJuros, ILogger<CalculaJurosController> logger)
        {
            _logger = logger;
            _calculadoraJuros = calculadoraJuros;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalulaJuros([FromQuery] decimal valorInicial, [FromQuery] int meses)
        {
            try
            {
                var valorJuros = await _calculadoraJuros.ExecutaCalculoJuros(valorInicial, meses);

                return Ok(new CalculoJurosResponse
                {
                    ValorTotal = valorJuros
                });
            }
            catch
            {
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }
    }
}