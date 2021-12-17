using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TrendyolCase.Core.ApiModels
{
    public abstract class BaseDto
    {
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
