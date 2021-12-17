using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Enums;

namespace TrendyolCase.Core.Entities
{
    public class ConvertedLink : BaseEntity
    {
        public string WebUrl { get; set; }
        public string DeepLink { get; set; }
        public Page Page { get; set; }
        public Direction Direction { get; set; }
    }
}
