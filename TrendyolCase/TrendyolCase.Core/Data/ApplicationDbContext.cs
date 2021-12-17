using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrendyolCase.Core.Entities;

namespace TrendyolCase.Core.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ExceptionInfo> ExceptionInfo { get; set; }
        public DbSet<ConvertedLink> ConvertedLink { get; set; }
    }
}
