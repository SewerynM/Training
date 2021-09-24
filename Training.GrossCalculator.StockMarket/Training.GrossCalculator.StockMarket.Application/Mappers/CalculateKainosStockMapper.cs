using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Application.Mappers
{
    public class CalculateKainosStockMapper
    {
        public static void Map(CalculateKainosStockRequest request, dynamic data)
        {
            if (data == null)
            {
                return;
            }

            request.Total = data.Total;
        }
    }
}