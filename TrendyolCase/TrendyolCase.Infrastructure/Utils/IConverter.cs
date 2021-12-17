using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Enums;

namespace TrendyolCase.Infrastructure.Utils
{
    public interface IConverter
    {
        string ConvertedLink { get; }
        Page Page { get; }
        bool Convert(string link);
    }
}
