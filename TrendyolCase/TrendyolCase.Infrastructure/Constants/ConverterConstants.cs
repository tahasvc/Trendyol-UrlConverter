using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolCase.Infrastructure.Constants
{
    public static class ConverterConstants
    {
        public static class Web
        {
            public static string Url = "https://www.trendyol.com";
            public static string Search = "/sr?q=";
            public static string Boutique = "boutiqueId=";
            public static string Merchant = "merchantId=";
            public static  string Product = "/brand/name-p-";
        }

        public static class Deep
        {
            public static  string Base = "ty://?Page=";
            public static  string Home = "Home";
            public static  string Product = "Product&ContentId=";
            public static  string Search = "Search&Query=";
            public static  string Campaing = "CampaignId=";
            public static  string Merchant = "MerchantId=";
        }

        public static class Regex
        {
            public static string Id = "[0-9]+";
            public static string Search = "[a-zA-Z%0-9]+";
            public static string WebProductPage = "\\/[^\\/]+\\/[^\\/]*-p-[0-9]+[^\\/]*";
            public static string WebSearchPage = "\\/sr\\?q=[^\\/]+";
            public static string DeepLinkSearchPage = "Search\\&Query=[^\\/]+";
            public static string DeepLinkProductPage= "Product\\&ContentId=[0-9]+[^\\/]*";
        }
    }
}
