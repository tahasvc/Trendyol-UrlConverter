using TrendyolCase.Core.Enums;
using TrendyolCase.Infrastructure.Constants;

namespace TrendyolCase.Infrastructure.Utils.Weblink
{
    public class WebLinkConverter : IConverter
    {
        private string convertedLink;
        private Page page;
        private IConverter converter;
        public string ConvertedLink => convertedLink;
        public Page Page => page;

        /// <summary>
        /// Converts deep link to web link
        /// Link may belong to Product, Search or Other Pages. 
        /// </summary>
        /// <param name="link">Url to convert</param>
        public bool Convert(string link)
        {
            convertedLink = ConverterConstants.Web.Url;
            page = Page.OtherPage;

            if (link.StartsWith(ConverterConstants.Deep.Base))
            {
                link = link.Replace(ConverterConstants.Deep.Base, "");

                if (link.Matches(ConverterConstants.Regex.DeepLinkProductPage))
                {
                    converter = new ProductPageConverter();
                }
                else if (link.Matches(ConverterConstants.Regex.DeepLinkSearchPage))
                {
                    converter = new SearchPageConverter();
                }

            }

            if (converter != null)
            {
                converter.Convert(link);
                convertedLink += converter.ConvertedLink;
                page = converter.Page;
            }

            return true;
        }
    }
}
