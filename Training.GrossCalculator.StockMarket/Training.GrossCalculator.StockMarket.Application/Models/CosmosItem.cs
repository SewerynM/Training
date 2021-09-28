using System;
using Newtonsoft.Json;

namespace Training.GrossCalculator.StockMarket.Application.Models
{
    public class CosmosItem
    {
        public CosmosItem(Item item)
        {
            ClientId = item.ClientId;
            Name = item.Name;
            Category = item.Category;
            PriceNet = item.PriceNet;
            Id = Guid.NewGuid().ToString();
        }

        [JsonProperty("id")]
        public string Id { set; get; }

        public string ClientId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public float PriceNet { get; set; }
    }
}