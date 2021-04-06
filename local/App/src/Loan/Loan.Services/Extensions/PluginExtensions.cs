using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Loan.Core.Plugin;
using Loan.Data;

namespace Loan.Services.Extensions
{
    public static class PluginExtensions
    {
        public static IApplicationBuilder RegisterPlugins(this IApplicationBuilder app, string cnn)
        {
            var dbContext = new LoanDbContextFactory().Create(cnn);
            try
            {
                foreach (var item in new PluginFinder().FindAllPlugins())
                {
                    dbContext.Plugins.Add(new Entities.Global.Plugin()
                    {
                        CreatedOn = DateTime.Now,
                        ApiKey = item.ApiKey,
                        ApiUrl = item.ApiUrl,
                        WebSite = item.WebSite,
                        Name = item.Name
                    });
                }
                dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.StackTrace);
            }
            finally
            {
                dbContext.Dispose();
            }
            return app;
        }
    }
}