namespace Loan.Services
{
    using Loan.Entities;
    using Loan.Repositories;
    public class BaseService<T>
        where T : BaseEntity
    {
        public BaseService(BaseRepository<T> repository){

        }
    }
}
