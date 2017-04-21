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

        /// <summary>
        /// // GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(JsonResult), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ExecuteAsync();

            if (!result.Any())
                return NotFound();

            return new JsonResult(result);
        }

        [HttpGet("params")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Get(string tipo, bool? possuiCupom, int? ano)
        {
            try
            {
                var tipoDeTitulo = EnumExtension.GetEnumValueFromDescription<TipoDeTituloEnum>(tipo);

                var result = await _service.ExecuteAsync(tipoDeTitulo, possuiCupom, ano);

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
