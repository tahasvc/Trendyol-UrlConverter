using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Npgsql.TypeMapping;
using TrendyolCase.Core.ApiModels;
using TrendyolCase.Core.Entities;
using TrendyolCase.Core.Enums;
using TrendyolCase.Core.Interfaces.Repositories;
using TrendyolCase.Core.Interfaces.Services;
using TrendyolCase.Infrastructure.Utils.Deeplink;
using TrendyolCase.Infrastructure.Utils.Weblink;

namespace TrendyolCase.Infrastructure.Services
{
    public class ConverterService : IConverterService
    {
        private readonly IConverterRepository _converterRepository;
        public ConverterService(IConverterRepository converterRepository)
        {
            _converterRepository = converterRepository;
        }

        /// <summary>
        /// The service is web to deep link converter
        /// </summary>
        /// <param name="convertedLinkDto">Url to convert</param>
        /// <returns></returns>
        public async Task<ConvertedLinkDto> ConvertToDeepLink(ConvertedLinkDto convertedLinkDto)
        {
            var converter = new DeepLinkConverter();
            converter.Convert(convertedLinkDto.Link);
            var entity = new ConvertedLink
            {
                Direction = Direction.ToDeepLink,
                Page = converter.Page,
                DeepLink = converter.ConvertedLink,
                WebUrl = convertedLinkDto.Link
            };

            convertedLinkDto.Link = converter.ConvertedLink;
            await _converterRepository.AddAsync(entity);

            return convertedLinkDto;
        }

        /// <summary>
        /// The service is deep to web link converter
        /// </summary>
        /// <param name="convertedLinkDto">Url to convert</param>
        /// <returns></returns>
        public async Task<ConvertedLinkDto> ConvertToWebLink(ConvertedLinkDto convertedLinkDto)
        {
            var converter = new WebLinkConverter();
            converter.Convert(convertedLinkDto.Link);
            var entity = new ConvertedLink
            {
                Direction = Direction.ToWebUrl,
                Page = converter.Page,
                DeepLink = converter.ConvertedLink,
                WebUrl = convertedLinkDto.Link
            };

            convertedLinkDto.Link = converter.ConvertedLink;
            await _converterRepository.AddAsync(entity);

            return convertedLinkDto;
        }
    }
}
