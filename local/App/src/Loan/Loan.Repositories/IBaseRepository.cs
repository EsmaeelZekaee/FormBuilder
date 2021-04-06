namespace Loan.Repositories
{
    using Loan.Entities;

    public interface IBaseRepository
    {

    }

    public interface IBaseRepository<T> : IBaseRepository where T : BaseEntity
    {

    }
}