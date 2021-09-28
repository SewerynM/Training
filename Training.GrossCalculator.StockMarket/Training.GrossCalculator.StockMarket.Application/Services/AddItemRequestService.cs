using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Training.GrossCalculator.StockMarket.Application.Connectors;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application
{
    public class AddItemRequestService : IExecutable<AddItemRequest, AddItemResponse>
    {
        private readonly IItemsCosmosDBConnector _itemsCosmosDbConnector;
        private AddItemRequest _request;
        
        public AddItemRequestService(IItemsCosmosDBConnector itemsCosmosDbConnector)
        {
            _itemsCosmosDbConnector = itemsCosmosDbConnector;
        }

        public async Task<AddItemResponse> ExecuteAsync(AddItemRequest request)
        {
            _request = request;
            /*foreach (Item item in _request.Items)*/
            for(var i = 0; i < request.Items.Length; i++)
            {
                await _itemsCosmosDbConnector.AddItemsToContainerAsync(new CosmosItem(request.Items[i]));
            }
            return await Task.FromResult(new AddItemResponse());
        }
    }
}
