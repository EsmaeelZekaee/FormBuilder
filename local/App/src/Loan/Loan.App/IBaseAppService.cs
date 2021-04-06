namespace Loan.Services
{
    using Loan.Entities;
    using Loan.Repositories;
    public interface IBaseAppService
    {

    }
 
    public interface IBaseAppService<T> : IBaseAppService where T : BaseEntity
    {

    }

}
