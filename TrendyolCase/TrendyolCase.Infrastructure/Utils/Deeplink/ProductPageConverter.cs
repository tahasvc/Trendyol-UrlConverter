using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Enums;
using TrendyolCase.Infrastructure.Constants;

namespace TrendyolCase.Infrastructure.Utils.Deeplink
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
            link = link.Substring(link.LastIndexOf("/") + 1);
            var product = link.Substring(link.IndexOf("-p-") + 3);
            var productId = product;
            var boutiqueId = "";
            var merchanId = "";

            if (product.Contains("?"))
            {
                productId = product.Substring(0, product.IndexOf("?"));
                product = product.Substring(product.IndexOf("?") + 1);
                boutiqueId = Helper.GetParameterValue(product, ConverterConstants.Web.Boutique);
                merchanId = Helper.GetParameterValue(product, ConverterConstants.Web.Merchant);
            }

            if (productId.Matches(ConverterConstants.Regex.Id) && boutiqueId != null && merchanId != null)
            {
                convertedLink = ConverterConstants.Deep.Product + productId;

                if (boutiqueId.Matches(ConverterConstants.Regex.Id))
                {
                    convertedLink += "&" + ConverterConstants.Deep.Campaing + boutiqueId;
                }

                if (merchanId.Matches(ConverterConstants.Regex.Id))
                {
                    convertedLink += "&" + ConverterConstants.Deep.Merchant + merchanId;
                }

                page = Page.ProductDetailPage;

                return true;
            }

            return false;
        }
    }
}
