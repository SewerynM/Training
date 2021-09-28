using System.Dynamic;

namespace Training.GrossCalculator.StockMarket.Application.Configuration
{
    public class CosmosDbConfiguration
    {
        public string CosmosDbConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string ContainerName { get; set; }
    }
}