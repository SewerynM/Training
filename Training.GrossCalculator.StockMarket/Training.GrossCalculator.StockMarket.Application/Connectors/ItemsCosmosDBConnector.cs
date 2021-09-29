using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public async Task<GetInvoiceResponse> GetItemsPerClientId(string ClientId)
        {
            List<ResponseItem> items = new List<ResponseItem>();
            decimal total = 0;

            QueryDefinition queryDefinition =
                new QueryDefinition("SELECT * FROM c WHERE c.ClientId = @clientId").WithParameter("@clientId",
                    ClientId);
            using (FeedIterator feedIterator = _container.GetItemQueryStreamIterator(queryDefinition))
            {
                while (feedIterator.HasMoreResults)
                {
                    using (ResponseMessage response = await feedIterator.ReadNextAsync())
                    {
                        using (StreamReader sr = new StreamReader(response.Content))
                        using (JsonTextReader jtr = new JsonTextReader(sr))
                        {
                            JObject result = JObject.Load(jtr);
                            foreach (var document in result["Documents"])
                            {
                                items.Add(new ResponseItem()
                                {
                                    Name = document["Name"].ToString(),
                                    PriceGross = document["PriceGross"].ToObject<Decimal>()
                                });
                                total += document["PriceGross"].ToObject<Decimal>();
                            }
                        }
                    }
                }
            }
            
            return new GetInvoiceResponse()
            {
                itemList = items.ToArray(),
                Total = total
            };
        }
    }
}