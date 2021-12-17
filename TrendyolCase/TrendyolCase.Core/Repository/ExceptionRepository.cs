using System.Collections.Generic;
using System.Threading.Tasks;
using TrendyolCase.Core.Data;
using TrendyolCase.Core.Entities;
using TrendyolCase.Core.Interfaces.Repositories;

namespace TrendyolCase.Core.Repository
{
    public class ExceptionRepository : Repository<ExceptionInfo>, IExceptionRepository
    {
        public ExceptionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
