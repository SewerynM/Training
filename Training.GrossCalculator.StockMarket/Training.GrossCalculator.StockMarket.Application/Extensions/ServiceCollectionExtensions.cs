using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Training.GrossCalculator.StockMarket.Application.Configuration;
using Training.GrossCalculator.StockMarket.Application.Connectors;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services, CosmosDbConfiguration cosmosDbConfiguration)
        {
            services.AddTransient<IItemsCosmosDBConnector, ItemsCosmosDBConnector>();
            services.AddTransient<Container>(provider =>
            {
                CosmosClient cosmosClient = new CosmosClientBuilder(cosmosDbConfiguration.CosmosDbConnectionString).Build();
                return cosmosClient.GetContainer(cosmosDbConfiguration.DatabaseName, cosmosDbConfiguration.ContainerName);
            });
            services.AddTransient<IExecutable<AddItemRequest, AddItemResponse>, AddItemRequestService>();
        }
    }
}
