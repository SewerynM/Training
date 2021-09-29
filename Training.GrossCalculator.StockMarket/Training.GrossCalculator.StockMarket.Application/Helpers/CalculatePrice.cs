using System;

namespace Training.GrossCalculator.StockMarket.Application.Helpers
{
    public class CalculatePrice
    {
        public static decimal CalculatePriceGrossFromPriceNet(decimal priceNet)
        {
            decimal rate = new Decimal(0.23);
            return (priceNet * rate) + priceNet;
        }

        public static decimal CalculatePriceGrossFromPriceNet(decimal priceNet, decimal rate)
        {
            return (priceNet * rate) + priceNet;
        }
    }
}