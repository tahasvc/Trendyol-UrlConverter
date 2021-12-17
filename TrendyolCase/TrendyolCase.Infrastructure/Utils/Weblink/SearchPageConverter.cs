using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Enums;
using TrendyolCase.Infrastructure.Constants;

namespace TrendyolCase.Infrastructure.Utils.Weblink
{
    public class SearchPageConverter : IConverter
    {
        private string convertedLink;
        private Page page;

        public string ConvertedLink => convertedLink;

        public Page Page => page;

        /// <summary>
        /// Url convert with search
        /// </summary>
        /// <param name="link">Url to convert with search link</param>
        /// <returns></returns>
        public bool Convert(string link)
        {
            var searchQueryParams = link.Replace(ConverterConstants.Deep.Search, "");

            if (searchQueryParams.Matches(ConverterConstants.Regex.Search))
            {
                convertedLink = ConverterConstants.Web.Search + searchQueryParams;
                page = Page.SearchPage;

                return true;
            }

            return false;
        }
    }
}
