using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TesouroDiretoAPI.Common;

namespace TesouroDiretoAPI
{
    /// <summary>
    /// Título do Tesouro Direto
    /// </summary>
    public class Titulo
    {
        /// <summary>
        /// Cria uma nova Instância de Título de acordo com os Dados Passados
        /// </summary>
        /// <param name="tipo">Tipo do Título</param>
        /// <param name="taxaCompra">Taxa de Compra</param>
        /// <param name="taxaVenda">Taxa de Venda</param>
        /// <param name="puCompra">Preço Unitário de Compra</param>
        /// <param name="puVenda">Preço Unitário de VEnda</param>
        public Titulo(TitulosDisponiveisEnum tipo, decimal taxaCompra, decimal taxaVenda, decimal puCompra, decimal puVenda)
        {
            TipoDeTitulo = tipo;
            TaxaCompra = taxaCompra;
            TaxaVenda = taxaVenda;
            PrecoUnitarioCompra = puCompra;
            PrecoUnitarioVenda = puVenda;
        }

        /// <summary>
        /// Tipo do Título
        /// </summary>
        private TitulosDisponiveisEnum TipoDeTitulo { get; set; }

        /// <summary>
        /// Descrição do Título
        /// </summary>
        public string Descricao { get { return TipoDeTitulo.GetDescription(); } }

        /// <summary>
        /// Data de Vencimento do Título
        /// </summary>
        public string Vencimento { get { return TipoDeTitulo.GetVencimento(); } }

        /// <summary>
        /// Sigla do Tipo do Título
        /// </summary>
        public string Sigla { get { return TipoDeTitulo.GetSigla(); } }

        /// <summary>
        /// Indica se o título paga cupoms semestrais
        /// </summary>
        public bool PossuiCupom { get { return TipoDeTitulo.GetDescription().Contains("Juros"); } }

        /// <summary>
        /// Ano de Vencimento do Título
        /// </summary>
        public int AnoVencimento { get { return DateTime.Parse(Vencimento).Year; } }

        /// <summary>
        /// Taxa de Compra na Data Atual
        /// </summary>
        public decimal TaxaCompra { get; private set; }

        /// <summary>
        /// Taxa de Venda na Data Atual
        /// </summary>
        public decimal TaxaVenda { get; private set; }

        /// <summary>
        /// Preço Unitário de Compra na Data Atual
        /// </summary>
        public decimal PrecoUnitarioCompra { get; private set; }

        /// <summary>
        /// Preço Unitário de Venda na Data Atual
        /// </summary>
        public decimal PrecoUnitarioVenda { get; private set; }

        //public string Vencimento { get { return  } }

        /// <summary>
        /// Indica se o Título está à Venda
        /// </summary>
        public bool TituloAVenda { get { return TaxaCompra > 0; } }
    }
}
