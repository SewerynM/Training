using System;
using System.Threading.Tasks;
using Training.GrossCalculator.StockMarket.Application.Connectors;
using Training.GrossCalculator.StockMarket.Application.Helpers;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application
{
    public class UpdateItemPriceGrossService : IExecutable<CosmosItem, UpdatePriceGrossResponse>
    {

        private readonly IItemsCosmosDBConnector _itemsCosmosDbConnector;

        public UpdateItemPriceGrossService(IItemsCosmosDBConnector itemsCosmosDbConnector)
        {
            _itemsCosmosDbConnector = itemsCosmosDbConnector;
        }

        public async Task<UpdatePriceGrossResponse> ExecuteAsync(CosmosItem cosmosItem)
        {
            await _itemsCosmosDbConnector.AddItemsToContainerAsync(new CosmosItem
            {
                Category = cosmosItem.Category,
                ClientId = cosmosItem.ClientId,
                Id = cosmosItem.Id,
                Name = cosmosItem.Name,
                PriceNet = cosmosItem.PriceNet,
                PriceGross = CalculatePrice.CalculatePriceGrossFromPriceNet(cosmosItem.PriceNet)

            });
            return await Task.FromResult(new UpdatePriceGrossResponse());
        }
    }
}