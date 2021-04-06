namespace Loan.Entities.Statistics
{
    using Loan.Entities;
    using Loan.Entities.Global;
    
    public class CollectedInfo : BaseEntity
    {
        public Currency Currency { get; set; }
        public long CurrencyId { get; set; }
    }
}