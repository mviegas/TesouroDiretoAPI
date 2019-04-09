using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TesouroDiretoAPI.Common
{
    /// <summary>
    /// Tipos de Títulos à Venda
    /// </summary>
    public enum TipoDeTituloEnum
    {
        /// <summary>
        /// Tesouro Prefixado
        /// </summary>
        [Description("Prefixado")]
        Prefixado,
        /// <summary>
        /// Atrelado ao IPCA
        /// </summary>
        [Description("IPCA")]
        IPCA,
        /// <summary>
        /// Atrelado ao IGPM
        /// </summary>
        [Description("IGPM")]
        IGPM,
        /// <summary>
        /// Atrelado à SELIC
        /// </summary>
        [Description("Selic")]
        Selic
    }
}
