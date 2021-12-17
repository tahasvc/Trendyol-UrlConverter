using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Enums;
using TrendyolCase.Infrastructure.Constants;

namespace TrendyolCase.Infrastructure.Utils.Weblink
{
    public class ProductPageConverter : IConverter
    {
        private string convertedLink;
        private Page page;
        public string ConvertedLink => convertedLink;
        public Page Page => page;

        /// <summary>
        /// Url convert with product
        /// </summary>
        /// <param name="link">Url to convert with product link</param>
        /// <returns></returns>
        public bool Convert(string link)
        {
            link = link.Replace(ConverterConstants.Deep.Product, "");
            var productId = link;
            var campaignId = string.Empty;
            var merchantId = string.Empty;

            if (link.Contains("&"))
            {
                productId = link.Substring(0, link.IndexOf("&"));
                link = link.Substring(link.IndexOf("&") + 1);
                campaignId = Helper.GetParameterValue(link, ConverterConstants.Deep.Campaing);
                merchantId = Helper.GetParameterValue(link, ConverterConstants.Deep.Merchant);
            }

            if (productId.Matches(ConverterConstants.Regex.Id))
            {
                convertedLink = ConverterConstants.Web.Product + productId;

                if (merchantId.Matches(ConverterConstants.Regex.Id) || campaignId.Matches(ConverterConstants.Regex.Id))
                    convertedLink += "?";

                if (campaignId.Matches(ConverterConstants.Regex.Id))
                    convertedLink += ConverterConstants.Web.Boutique + campaignId;

                if (merchantId.Matches(ConverterConstants.Regex.Id))
                {
                    if (campaignId.Matches(ConverterConstants.Regex.Id))
                        convertedLink += "&";

                    convertedLink += ConverterConstants.Web.Merchant + merchantId;
                }

                page = Page.ProductDetailPage;

                return true;
            }

            return false;
        }
    }
}
