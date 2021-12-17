using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrendyolCase.Infrastructure.Constants;

namespace TrendyolCase.Infrastructure.Utils
{
    public static class Helper
    {
        /// <summary>
        /// Returns the values of the parameters in the link
        /// </summary>
        /// <param name="param">Parameters</param>
        /// <param name="key">The value of which parameter</param>
        /// <returns></returns>
        public static string GetParameterValue(string param, string key)
        {
            var result = string.Empty;

            if (param.Contains(key))
            {
                var variable = param.Substring(param.IndexOf(key));
                var lastIndex = variable.Length;

                if (variable.Contains("&"))
                    lastIndex = variable.IndexOf("&");

                var startIndex = key.Length;
                int length = lastIndex - startIndex;
                var value = variable.Substring(startIndex, length);

                result = value.Matches(ConverterConstants.Regex.Id) ? value : null;
            }

            return result;
        }

        /// <summary>
        /// Match check in related text
        /// </summary>
        /// <param name="value">Related text</param>
        /// <param name="rxValue">Regex pattern</param>
        /// <returns></returns>
        public static bool Matches(this string value,string rxValue)
        {
            var regex = new Regex(@rxValue);
            var matches = regex.Matches(value);

            return matches.Count > 0;
        }
    }
}
