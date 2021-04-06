using Loan.Entities.Global;
using Loan.Entities.Statistics;
using Microsoft.EntityFrameworkCore;

namespace Loan.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CollectedInfo> CollectedInfos { get; set; }

        public DbSet<Plugin> Plugins { get; set; }
    }
}