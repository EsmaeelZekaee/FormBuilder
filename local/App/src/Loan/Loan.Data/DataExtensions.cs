namespace Loan.Data
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;


    public static class DataExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services)
        {
            services.AddDbContext<LoanDbContext>();
        }

        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<LoanDbContext>(new LoanDbContextFactory().OptionBuilder(configuration.GetConnectionString("local")));
        }
    }
}