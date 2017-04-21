using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TesouroDiretoAPI.Common
{
    /// <summary>
    /// Atributo para Descrição de Títulos do Tesouro Direto
    /// </summary>
    public class TituloDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Construtor sem Parâmetros
        /// </summary>
        public TituloDescriptionAttribute() : base()
        {
            Vencimento = String.Empty;
        }

        /// <summary>
        /// Inicializa as variáveis Descrição e Vencimento
        /// </summary>
        /// <param name="descricao">Descrição do Título</param>
        /// <param name="vencimento">Data de Vencimento</param>
        public TituloDescriptionAttribute(string descricao, string vencimento = "") : base(descricao)
        {
            Vencimento = vencimento;
        }

        public string Vencimento { get; private set; }
    }
}
