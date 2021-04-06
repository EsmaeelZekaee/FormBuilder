namespace Loan.Core.Plugin
{
    public interface IPlugin
    {
        string Name { get; }

        string WebSite { get; }

        string ApiKey { get; }

        string ApiUrl { get; }

        void FetchData();

    }
}