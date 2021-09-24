using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Training.GrossCalculator.StockMarket.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            
        }

        public static void AddCosmosRepositories(IServiceCollection services, dynamic secrets)
        {

        }
    }
}
