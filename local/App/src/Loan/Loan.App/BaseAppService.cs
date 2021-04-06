namespace Loan.App
{
    using Loan.Entities;
    using Loan.Services;

    public class BaseAppService<T>: IBaseAppService    where T : BaseEntity
    {
        public BaseAppService(IBaseService<T> service){

        }

    }
}