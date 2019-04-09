using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesouroBot.API.Helpers
{
    public class TesouroBotTableParser
    {
        public static async Task<JsonResult> FetchAsync(string name)
        {
            var web = new HtmlAgilityPack.HtmlWeb();
            var doc = await web.LoadFromWebAsync("http://www.tesouro.fazenda.gov.br/tesouro-direto-precos-e-taxas-dos-titulos");

            var tables = doc
                .DocumentNode
                .Descendants()
                .Where(n => n.Name == "table" && n.HasClass("tabelaPrecoseTaxas"));

            var bonds = new List<Titulo>();

            foreach (var table in tables)
            {
                var tableNodes = table
                    .Descendants()
                    .Where(n => n.Name == "tr" && n.HasClass("camposTesouroDireto"));

                foreach (var tableNode in tableNodes)
                {
                    var values = tableNode
                        .Descendants()
                        .Where(d => d.Name == "td")
                        .ToArray();

                    var bond = values.Length >= 5 ?
                        new Titulo(values[0].InnerHtml,
                            values[1].InnerHtml,
                            values[2].InnerHtml,
                            values[3].InnerHtml.Replace("R$", string.Empty).Replace(".", string.Empty),
                            values[4].InnerHtml.Replace("R$", string.Empty).Replace(".", string.Empty), TipoDeTitulo.Compra) :
                        new Titulo(values[0].InnerHtml,
                            values[1].InnerHtml,
                            values[2].InnerHtml,
                            null,
                            values[3].InnerHtml.Replace("R$", string.Empty).Replace(".", string.Empty), TipoDeTitulo.Venda);

                    bonds.Add(bond);
                }
            }

            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        
            return new JsonResult(bonds.Where(t => string.IsNullOrEmpty(name) ? true : t.Nome.ToUpperInvariant().Contains(name.ToUpperInvariant())), settings);
        }

        private class Titulo
        {
            public Titulo(string nome, string vencimento, string taxa, string valorMinimoDeCompra, string precoUnitario, TipoDeTitulo tipoDeTitulo)
            {
                Nome = nome;
                Vencimento = vencimento;
                Taxa = taxa;
                ValorMinimoDeCompra = valorMinimoDeCompra;
                PrecoUnitario = precoUnitario;
                TipoDeTitulo = tipoDeTitulo;
            }

            public string Nome { get; set; }
            public string Vencimento { get; set; }
            public string Taxa { get; set; }
            public string ValorMinimoDeCompra { get; set; }
            public string PrecoUnitario { get; set; }

            [JsonConverter(typeof(StringEnumConverter))]
            public TipoDeTitulo TipoDeTitulo { get; set; }
        }
        
        private enum TipoDeTitulo
        {
            Compra,
            Venda
        }
    }
}
