﻿namespace Training.GrossCalculator.StockMarket.Application.Models
{
    public class Item
    {
        public Item(string clientId, string name, string category, float priceNet)
        {
            this.ClientId = clientId;
            this.Name = name;
            this.Category = category;
            this.PriceNet = priceNet;
        }

        public string ClientId { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public float PriceNet { get; set; }

        public string GuId { set; get; }
    }
}