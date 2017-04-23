using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TesouroDiretoAPI.Common;

namespace TesouroDiretoAPI
{
    /// <summary>
    /// Serviço que executa a transfomração dos dados disponíveis no site do Tesouro Direto
    /// </summary>
    public class ParseDadosDoTituloService
    {
        /// <summary>
        /// Executa o Parse retornando os Títulos disponíveis no Site do Tesouro
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Titulo>> ExecuteAsync(string tipoDoTitulo = null, bool? possuiCupom = null, int? ano = null, string sigla = null)
        {
            var client = new HttpClient();
            string page = await client.GetStringAsync("http://www3.tesouro.gov.br/tesouro_direto/consulta_titulos_novosite/consultatitulos.asp");

            var doc = new HtmlDocument();
            doc.LoadHtml(page);

            var table = doc.DocumentNode.SelectSingleNode("//table")
                .Descendants()
                .Skip(1)
                .Where(tr => tr.Elements("td").Count() > 1)
                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                .Skip(3)
                .ToList();

            var titulos = new List<Titulo>();

            foreach (var register in table.Where(tableItem => tableItem.Count == 6))
            {
                var tipo = EnumExtension.GetEnumValueFromDescription<TitulosDisponiveisEnum>(register[0]);

                var taxaCompra = register[2].ParseToDecimal();
                var taxaVenda = register[3].ParseToDecimal();
                var puCompra = register[4].ParseToDecimal();
                var puVenda = register[5].ParseToDecimal();

                var titulo = new Titulo(tipo, taxaCompra, taxaVenda, puCompra, puVenda);

                titulos.Add(titulo);
            }

            titulos = titulos
                .Where(t => 
                    (tipoDoTitulo.IsNullOrEmpty() ? true : 
                        t.Descricao
                        .ToUpper()
                        .Contains(EnumExtension.GetEnumValueFromDescription<TipoDeTituloEnum>(tipoDoTitulo).GetDescription().ToUpper())) &&
                    (!possuiCupom.HasValue ? true : t.PossuiCupom == possuiCupom) &&
                    (!ano.HasValue ? true : t.AnoVencimento == ano) &&
                    (sigla.IsNullOrEmpty() ? true : t.Sigla == sigla))
                .ToList();

            return titulos;
        }
    }
}
