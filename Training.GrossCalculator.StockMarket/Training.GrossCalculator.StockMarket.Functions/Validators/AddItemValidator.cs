using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Training.GrossCalculator.StockMarket.Application.Models;

namespace Training.GrossCalculator.StockMarket.Functions.Validators
{
    public class AddItemValidator : AbstractValidator<AddItemRequest>
    {
        public AddItemValidator()
        {
            RuleFor(x => x.Items).Custom(ValidateClientId);
            RuleFor(x => x.Items).Custom(ValidatePriceNet);
            RuleFor(x => x.Items).Custom(ValidateName);
            RuleFor(x => x.Items).Custom(ValidateCategory);
        }

        private static void ValidateClientId(Item[] items, ValidationContext<AddItemRequest> context)
        {
            foreach (Item item in items)
            {
                if (item.ClientId.Length != 8)
                {
                    context.AddFailure("ClientID must be 8 characters long");
                }
            }
        }

        private static void ValidatePriceNet(Item[] items, ValidationContext<AddItemRequest> context)
        {
            foreach (Item item in items)
            {
                if (item.PriceNet < 0)
                {
                    context.AddFailure("Price Net must be bigger than 0");
                }

                if (item.PriceNet > 1000000)
                {
                    context.AddFailure("Price Net must be smaller than 1 million");
                }
            }
        }

        private static void ValidateName(Item[] items, ValidationContext<AddItemRequest> context)
        {
            foreach (Item item in items)
            {
                if (string.IsNullOrWhiteSpace(item.Name) || string.IsNullOrEmpty(item.Name))
                {
                    context.AddFailure("Item's name cannot be empty or null");
                }
            }
        }

        private static void ValidateCategory(Item[] items, ValidationContext<AddItemRequest> context)
        {
            foreach (Item item in items)
            {
                if (string.IsNullOrWhiteSpace(item.Category) || string.IsNullOrEmpty(item.Category))
                {
                    context.AddFailure("Item's category cannot be empty or null");
                }
            }
        }
    }
}