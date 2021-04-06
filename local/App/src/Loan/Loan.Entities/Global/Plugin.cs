namespace Loan.Entities.Global
{
    public class Plugin : BaseEntity
    {
        public string Name { get; set; }

        public string WebSite { get; set; }

        public string ApiUrl { get; set; }

        public string ApiKey { get; set; }
    }
}