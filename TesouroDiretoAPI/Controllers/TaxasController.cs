using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesouroDiretoAPI.Common;

namespace TesouroDiretoAPI.Controllers
{
    /// <summary>
    /// TEST
    /// </summary>
    [Route("api/[controller]")]
    public class TaxasController : Controller
    {
        private readonly ParseDadosDoTituloService _service;

        /// <summary>
        /// Construtor
        /// </summary>
        public TaxasController()
        {
            _service = new ParseDadosDoTituloService();
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Get(string tipo, bool? possuiCupom, int? ano, string sigla)
        {
            try
            {
                var result = await _service.ExecuteAsync(tipo, possuiCupom, ano, sigla);

                if (!result.Any())
                    return NotFound();

                return new JsonResult(result);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
