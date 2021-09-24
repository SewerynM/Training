namespace Training.GrossCalculator.StockMarket.Application.Models
{
    public class Item
    {
        public Item(string name, string category, float priceNet)
        {
            this.Name = name;
            this.Category = category;
            this.PriceNet = priceNet;
        }
        public string Name { get; set; }

        public string Category { get; set; }

        public float PriceNet { get; set; }
    }
}