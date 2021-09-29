using FluentValidation;
using Training.GrossCalculator.StockMarket.Application.Connectors;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Functions.Validators
{
    public class RequestValidator : AbstractValidator<AddItemRequest>
    {
        public RequestValidator()
        {
            RuleFor(x => x.Items).Custom(ValidateItemsArrayNotEmpty);
        }

        private static void ValidateItemsArrayNotEmpty(Item[] items, ValidationContext<AddItemRequest> context)
        {
            if (items.Length == 0)
            {
                context.AddFailure("Items array cannot be empty");
            }
        }
    }
}