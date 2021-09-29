using System;
using Newtonsoft.Json;

namespace Training.GrossCalculator.StockMarket.Application.Models
{
    public class CosmosItem
    {
        [JsonProperty("id")]
        public string Id { set; get; }

        public string ClientId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal PriceNet { get; set; }

        public decimal? PriceGross { get; set; }
    }
}