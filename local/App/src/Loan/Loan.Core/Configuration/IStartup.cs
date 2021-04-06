namespace Loan.Core.Configuration
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    
    public interface IStartup
    {
         void ConfigureServices(IServiceCollection services);
         void Configure(IApplicationBuilder app);
    }
}