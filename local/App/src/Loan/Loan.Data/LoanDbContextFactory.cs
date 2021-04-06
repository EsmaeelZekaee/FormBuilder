using System;
using Microsoft.EntityFrameworkCore;

namespace Loan.Data
{
    public class LoanDbContextFactory
    {
        public LoanDbContext Create(string cnn)
        {
            return new LoanDbContext(GetOptions(cnn));
        }

        public Action<DbContextOptionsBuilder> OptionBuilder(string cnn)
        {
            return options =>
            {
                options.UseNpgsql(cnn, options => { });
            };
        }

        public DbContextOptions GetOptions(string cnn)
        {
            var builder = new DbContextOptionsBuilder();
            OptionBuilder(cnn).Invoke(builder);
            return builder.Options;
        }
    }
}