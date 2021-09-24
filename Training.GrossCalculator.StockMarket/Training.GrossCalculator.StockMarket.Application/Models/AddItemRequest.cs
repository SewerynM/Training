namespace Training.GrossCalculator.StockMarket.Application.Models
{
    public class AddItemRequest
    {
        public string ClientId { get; set; }

        public Item[] Items { get; set; }
    }
}