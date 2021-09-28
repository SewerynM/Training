using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Cosmos;
using Training.GrossCalculator.StockMarket.Application.Configuration;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application.Connectors
{
    public class ItemsCosmosDBConnector : IItemsCosmosDBConnector
    {
        private Container _container;

        public ItemsCosmosDBConnector(Container container)
        {
            _container = container;
        }

        public async Task AddItemsToContainerAsync(CosmosItem item)
        {
            await _container.UpsertItemAsync(item);
        }
    }
}