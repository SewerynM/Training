namespace Training.GrossCalculator.StockMarket.Application.Models
{
    public class GetInvoiceResponse
    {
        public ResponseItem[] itemList { get; set; }

        public decimal Total { get; set; }
    }
}