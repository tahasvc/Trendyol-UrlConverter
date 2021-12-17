using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Enums;
using TrendyolCase.Infrastructure.Constants;

namespace TrendyolCase.Infrastructure.Utils.Deeplink
{
    public class DeepLinkConverter : IConverter
    {
        private string convertedLink;
        private Page page;
        private IConverter converter;

        public string ConvertedLink => convertedLink;
        public Page Page => page;

        /// <summary>
        /// Converts web link to deep link.
        /// Link may belong to Product, Search or Other Pages. 
        /// </summary>
        /// <param name="link">Url to convert</param>
        public bool Convert(string link)
        {
            convertedLink = ConverterConstants.Deep.Base;
            page = Page.OtherPage;

            if (link.StartsWith(ConverterConstants.Web.Url))
            {
                link = link.Replace(ConverterConstants.Web.Url, "");
                if (link.Matches(ConverterConstants.Regex.WebSearchPage))
                {
                    converter = new SearchPageConverter();
                }
                else if (link.Matches(ConverterConstants.Regex.WebProductPage))
                {
                    converter = new ProductPageConverter();
                }
            }

            if (converter != null)
            {
                converter.Convert(link);
                convertedLink += converter.ConvertedLink;
                page = converter.Page;
            }
            else
            {
                convertedLink += ConverterConstants.Deep.Home;
            }

            return true;
        }
    }
}
