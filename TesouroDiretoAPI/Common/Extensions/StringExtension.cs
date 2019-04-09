using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TesouroDiretoAPI.Common
{
    /// <summary>
    /// Métodos de extensão para String
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Converte um decimal numa string complexa. Ex.: R$9281,98
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static decimal ParseToDecimal(this string owner)
        {
            var replacedString = Regex.Replace(owner, @"[^0-9\,]+", "");

            decimal.TryParse(replacedString, out decimal parsedNumber);

            return parsedNumber;
        }

        /// <summary>
        /// Indica se a string está nula ou vazia
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string owner)
        {
            return string.IsNullOrEmpty(owner);
        }
    }
}
