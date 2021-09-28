﻿using System;
using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Training.GrossCalculator.StockMarket.Application.Extensions;
using Training.GrossCalculator.StockMarket.Functions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Training.GrossCalculator.StockMarket.Application.Configuration;
using Training.GrossCalculator.StockMarket.Functions.Functions;
using Training.GrossCalculator.StockMarket.Functions.Validators;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Training.GrossCalculator.StockMarket.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            ConfigureServices(builder.Services);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            CosmosDbConfiguration cosmosDbConfiguration = getCosmosDbConfiguration();
            serviceCollection.AddApplication(cosmosDbConfiguration);
            
            AddServices(serviceCollection);
        }
        
        private static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator<AddItem>, AddItemValidator>();
            serviceCollection.AddTransient<IValidator<CalculateKainosStockEqualToTotal>, CalculateKainosStockEqualToTotalValidator>();
            serviceCollection.AddTransient<IValidator<GetInvoicePerClientId>, GetInvoicePerClientIdValidator>();
        }

        private static CosmosDbConfiguration getCosmosDbConfiguration()
        {
            return new CosmosDbConfiguration
            {
                CosmosDbConnectionString = Environment.GetEnvironmentVariable("CosmosDbConnectionString"), 
                ContainerName = Environment.GetEnvironmentVariable("ContainerName"), 
                DatabaseName = Environment.GetEnvironmentVariable("DatabaseName")
        };
        }
    }
}