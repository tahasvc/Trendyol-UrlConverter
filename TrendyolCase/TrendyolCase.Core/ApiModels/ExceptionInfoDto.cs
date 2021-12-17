using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrendyolCase.Core.ApiModels
{
    public class ExceptionInfoDto : BaseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
