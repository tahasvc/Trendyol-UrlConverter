using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.ApiModels;

namespace TrendyolCase.Core.Interfaces.Services
{
    public interface IConverterService
    {
        /// <summary>
        /// Converted web link to deep link.
        /// Link may belong to Product, Search or Other Pages.
        /// </summary>
        /// <param name="convertedLinkDto">Url parameter to convert</param>
        /// <returns></returns>
        Task<ConvertedLinkDto> ConvertToDeepLink(ConvertedLinkDto convertedLinkDto);

        /// <summary>
        /// Converted deep link to web link
        /// Link may belong to Product, Search or Other Pages.
        /// </summary>
        /// <param name="convertedLinkDto">Url parameter to convert</param>
        /// <returns></returns>
        Task<ConvertedLinkDto> ConvertToWebLink(ConvertedLinkDto convertedLinkDto);
    }
}
