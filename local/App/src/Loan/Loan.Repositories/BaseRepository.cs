namespace Loan.Repositories
{
    using Loan.Data;
    using Loan.Entities;
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly LoanDbContext _loanDbContext;

        public BaseRepository(LoanDbContext loanDbContext)
        {
            _loanDbContext = loanDbContext;

        }
    }
}
