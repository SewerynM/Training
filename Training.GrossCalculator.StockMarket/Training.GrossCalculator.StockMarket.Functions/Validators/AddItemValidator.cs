using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Training.GrossCalculator.StockMarket.Functions.Validators
{
    public class AddItemValidator : AbstractValidator<AddItem>
    {

        private static void ValidateClientId(string clientId, ValidationContext<AddItem> context)
        {
            if (clientId.Length != 8)
            {
                context.AddFailure("ClientID must be 8 characters long");
            }
        }

        private static void ValidateItems(dynamic items, ValidationContext<AddItem> context)
        {
            if (items.Length == 0)
            {
                context.AddFailure("Items list cannot be empty");
            }

            foreach(dynamic item in items)
            {
                if (string.IsNullOrWhiteSpace(item.name) || string.IsNullOrEmpty(item.name))
                {
                    context.AddFailure("Item's name cannot be empty or null");
                }

                if (string.IsNullOrWhiteSpace(item.category) || string.IsNullOrEmpty(item.category))
                {
                    context.AddFailure("Item's category cannot be empty or null");
                }

                if (item.priceNet < 0)
                {
                    context.AddFailure("Price Net must be bigger than 0");
                }

                if (item.priceNet > 1000000)
                {
                    context.AddFailure("Price Net must be smaller than 1 million");
                }
            }

        }
    }
}