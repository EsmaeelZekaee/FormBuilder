namespace CryptoCompare
{
    using Microsoft.Extensions.DependencyInjection;
    using Loan.Core.Plugin;

    public class CryptoComparePlugin : IPlugin
    {
        public CryptoComparePlugin()
        {

        }
        
        public IServiceCollection Services { get; }

        public CryptoComparePlugin(IServiceCollection services)
        {
            this.Services = services;
        }

        public string Name => "CryptoCompare";
        public string WebSite => "http://CryptoCompare.com";
        public string ApiKey => "6ddc4020b3556d5505b0b04b3ae9563d5e1b1a12a5a3419a0c98c8ffd21aec0c";
        public string ApiUrl => "https://min-api.cryptocompare.com/";

        public void FetchData()
        {
            
        }
    }
}
