using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TrendyolCase.Core.ApiModels;
using TrendyolCase.Core.Interfaces.Services;

namespace TrendyolCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDeepLink : ControllerBase
    {
        private readonly IConverterService _converterService;
        public ToDeepLink(IConverterService converterService)
        {
            _converterService = converterService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConvertedLinkDto convertedLinkDto)
        {
            var result = await _converterService.ConvertToDeepLink(convertedLinkDto);

            return StatusCode((int)HttpStatusCode.OK, result);
        }

    }
}
