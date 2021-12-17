using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCase.Core.Data;
using TrendyolCase.Core.Entities;
using TrendyolCase.Core.Interfaces.Repositories;

namespace TrendyolCase.Core.Repository
{
    public class ConverterRepository : Repository<ConvertedLink>, IConverterRepository
    {
        public ConverterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
