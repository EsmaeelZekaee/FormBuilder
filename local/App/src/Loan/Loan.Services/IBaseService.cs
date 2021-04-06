namespace Loan.Services
{
    using Loan.Entities;
    public interface IBaseService
    {

    }
 
    public interface IBaseService<T> : IBaseService where T : BaseEntity
    {

    }
}