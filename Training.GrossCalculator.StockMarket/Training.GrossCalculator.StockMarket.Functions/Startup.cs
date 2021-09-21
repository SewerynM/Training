using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Training.GrossCalculator.StockMarket.Functions;
using Training.GrossCalculator.StockMarket.Application;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Training.GrossCalculator.StockMarket.Functions
{
    public class Startup : FunctionsStartup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {

        }

        private static void AddServices(IServiceCollection serviceCollection)
        {

        }

        public override void Configure(IFunctionsHostBuilder builder)
        {

        }
    }
}