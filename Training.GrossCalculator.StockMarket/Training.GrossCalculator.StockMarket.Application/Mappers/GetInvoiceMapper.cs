using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application.Mappers
{
    public class GetInvoiceMapper
    {
        public static void Map(GetInvoiceRequest request, dynamic data)
        {
            if (data == null)
            {
                return;
            }

            request.ClientId = data.ClientId;
        }
    }
}