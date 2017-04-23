namespace TesouroDiretoAPI.Common
{
    /// <summary>
    /// Títulos Disponíveis para Negociação com Descrição e Data de Vencimento
    /// </summary>
    public enum TitulosDisponiveisEnum
    {
        /// <summary>
        /// Título atrelado ao IGPM com Juros Semestrais com Vencimento em 2017
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IGPM+ com Juros Semestrais 2017", "01/07/2017", "NTNC")]
        IGPMComJurosSemestrais2017,

        /// <summary>
        /// Título atrelado ao IGPM com Juros Semestrais com Vencimento em 2021
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IGPM+ com Juros Semestrais 2021", "01/04/2021", "NTNC")]
        IGPMComJurosSemestrais2021,

        /// <summary>
        /// Título atrelado ao IGPM com Juros Semestrais com Vencimento em 2031
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IGPM+ com Juros Semestrais 2031", "01/01/2031", "NTNC")]
        IGPMComJurosSemestrais2031,

        /// <summary>
        /// Título atrelado ao IPCA com Juros Semestrais com Vencimento em 2017
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ com Juros Semestrais 2017", "15/05/2017", "NTNB")]
        IPCAComJurosSemestrais2017,

        /// <summary>
        /// Título atrelado ao IPCA com Vencimento em 2019
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ 2019", "15/05/2019", "NTNBPrincipal")]
        IPCA2019,

        /// <summary>
        /// Título atrelado ao IPCA com Juros Semestrais com Vencimento em 2020
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ com Juros Semestrais 2020", "15/08/2020", "NTNB")]
        IPCAComJurosSemestrais2020,

        /// <summary>
        /// Título atrelado ao IPCA com Juros Semestrais com Vencimento em 2024
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ com Juros Semestrais 2024", "15/08/2024", "NTNB")]
        IPCAComJurosSemestrais2024,

        /// <summary>
        /// Título atrelado ao IPCA com Vencimento em 2024
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ 2024", "15/08/2024", "NTNBPrincipal")]
        IPCA2024,

        /// <summary>
        /// Título atrelado ao IPCA com Juros Semestrais com Vencimento em 2026
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ com Juros Semestrais 2026", "15/08/2026", "NTNB")]
        IPCAComJurosSemestrais2026,

        /// <summary>
        /// Título atrelado ao IPCA com Juros Semestrais com Vencimento em 2035
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ com Juros Semestrais 2035", "15/05/2035", "NTNB")]
        IPCAComJurosSemestrais2035,

        /// <summary>
        /// Título atrelado ao IPCA com Vencimento em 2035
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ 2035", "15/05/2035", "NTNB")]
        IPCA2035,

        /// <summary>
        /// Título atrelado ao IPCA com Juros Semestrais com Vencimento em 2045
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ com Juros Semestrais 2045", "15/05/2045", "NTNB")]
        IPCAComJurosSemestrais2045,

        /// <summary>
        /// Título atrelado ao IPCA com Vencimento em 2045
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ 2045", "15/05/2045", "NTNB")]
        IPCA2045,

        /// <summary>
        /// Título atrelado ao IPCA com Juros Semestrais com Vencimento em 2050
        /// </summary>
        [TituloDescriptionAttribute("Tesouro IPCA+ com Juros Semestrais 2050", "15/08/2050", "NTNB")]
        IPCAComJurosSemestrais2050,

        /// <summary>
        /// Título Prefixado com Vencimento em 2018
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado 2018", "01/01/2018", "LTN")]
        Prefixado2018,

        /// <summary>
        /// Título Prefixado com Vencimento em 2019
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado 2019", "01/01/2019", "LTN")]
        Prefixado2019,

        /// <summary>
        /// Título Prefixado com Vencimento em 2020
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado 2020", "01/01/2020", "LTN")]
        Prefixado2020,

        /// <summary>
        /// Título Prefixado com Vencimento em 2021
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado 2021", "01/01/2021", "LTN")]
        Prefixado2021,

        /// <summary>
        /// Título Prefixado com Juros Semestrais com Vencimento em 2021
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado com Juros Semestrais 2021", "01/01/2021", "NTNF")]
        PrefixadoComJurosSemestrais2021,

        /// <summary>
        /// Título Prefixado com Juros Semestrais com Vencimento em 2023
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado com Juros Semestrais 2023", "01/01/2023", "NTNF")]
        PrefixadoComJurosSemestrais2023,

        /// <summary>
        /// Título Prefixado com Vencimento em 2023
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado 2023", "01/01/2023", "LTN")]
        Prefixado2023,

        /// <summary>
        /// Título Prefixado com Juros Semestrais com Vencimento em 2025
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado com Juros Semestrais 2025", "01/01/2025", "NTNF")]
        PrefixadoComJurosSemestrais2025,

        /// <summary>
        /// Título Prefixado com Juros Semestrais com Vencimento em 2027
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Prefixado com Juros Semestrais 2027", "01/01/2027", "NTNF")]
        PrefixadoComJurosSemestrais2027,

        /// <summary>
        /// Título atrelado à Taxa Selic com Vencimento em 2021
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Selic 2021", "01/03/2021", "LFT")]
        Selic2021,

        /// <summary>
        /// Título atrelado à Taxa Selic com Vencimento em 2023
        /// </summary>
        [TituloDescriptionAttribute("Tesouro Selic 2023", "01/03/2023", "LFT")]
        Selic2023
    }
}