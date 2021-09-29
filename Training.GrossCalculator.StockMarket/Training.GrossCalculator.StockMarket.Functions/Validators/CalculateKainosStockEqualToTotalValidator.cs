using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Training.GrossCalculator.StockMarket.Functions.Functions;

namespace Training.GrossCalculator.StockMarket.Functions.Validators
{
    public class CalculateKainosStockEqualToTotalValidator : AbstractValidator<ConvertTotalToKainosStockFunction>
    {
        private static void ValidateTotal(float total, ValidationContext<ConvertTotalToKainosStockFunction> context)
        {
            if (total < 0)
            {
                context.AddFailure("Total must be bigger than 0");
            }

            if (total > 10000000)
            {
                context.AddFailure("Total must be smaller than 10 million");
            }
        }

    }
}