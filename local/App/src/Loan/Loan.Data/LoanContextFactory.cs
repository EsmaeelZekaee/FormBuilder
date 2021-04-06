namespace Loan.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class LoanContextFactory : IDesignTimeDbContextFactory<LoanDbContext>
    {
        public LoanDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LoanDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=loan-local;User Id=loan;Password=Ivy_890;");

            return new LoanDbContext(optionsBuilder.Options);
        }
    }
}
