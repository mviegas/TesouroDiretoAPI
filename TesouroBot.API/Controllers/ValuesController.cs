using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesouroBot.API.Helpers;

namespace tesourobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Busca os títulos disponíveis para compra/venda
        /// </summary>
        /// <param name="nome">Filtro por nome do título, ou parte dele</param>
        /// <returns>Listagem dos títulos disponíveis</returns>
        // GET api/values
        [HttpGet]
        public async Task<JsonResult> Get(string nome)
        {
            var jsonResult = await TesouroBotTableParser.FetchAsync(nome);

            return jsonResult;
        }
    }
}