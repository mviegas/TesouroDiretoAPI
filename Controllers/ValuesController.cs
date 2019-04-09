using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace tesourobot.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        // GET api/values
        [HttpGet]
        public async Task<string> Get () {
            var web = new HtmlAgilityPack.HtmlWeb ();
            var doc = await web.LoadFromWebAsync ("http://www.tesouro.fazenda.gov.br/tesouro-direto-precos-e-taxas-dos-titulos");

            var tables = doc.DocumentNode
                .DescendantNodes ()
                .Where (n => n.Name == "table" && n.HasClass ("tabelaPrecoseTaxas"));

            var titulos = new List<Titulo> ();

            foreach (var table in tables) {
                var tableNodes = table.DescendantNodes ()
                    .Where (n => n.Name == "tr" && n.HasClass ("camposTesouroDireto"));

                foreach (var tableNode in tableNodes) {
                    var values = tableNode.DescendantNodes ()
                        .Where (d => d.Name == "td")
                        .ToArray ();

                    var titulo = values.Length >= 5 ?
                        new Titulo (values[0].InnerHtml, values[1].InnerHtml, values[2].InnerHtml, values[3].InnerHtml, values[4].InnerHtml) : 
                        new Titulo (values[0].InnerHtml, values[1].InnerHtml, values[2].InnerHtml, string.Empty, values[3].InnerHtml);

                    titulos.Add (titulo);
                }
            }

            return JsonConvert.SerializeObject (titulos.OrderBy(t => t.Vencimento));
        }

        private class Titulo {
            public Titulo (string nome, string vencimento, string taxa, string valorMinimoDeCompra, string precoUnitario) {
                Nome = nome;
                Vencimento = vencimento;
                Taxa = taxa;
                ValorMinimoDeCompra = valorMinimoDeCompra;
                PrecoUnitario = precoUnitario;
            }

            public string Nome { get; set; }
            public string Vencimento { get; set; }
            public string Taxa { get; set; }
            public string ValorMinimoDeCompra { get; set; }
            public string PrecoUnitario { get; set; }
        }
    }
}