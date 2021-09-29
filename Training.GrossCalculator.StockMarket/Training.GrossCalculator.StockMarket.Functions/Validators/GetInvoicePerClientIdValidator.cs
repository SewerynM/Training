using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Training.GrossCalculator.StockMarket.Functions.Functions;

namespace Training.GrossCalculator.StockMarket.Functions.Validators
{
    public class GetInvoicePerClientIdValidator : AbstractValidator<GetInvoicePerClientIdFunction>
    {
        private static void ValidateClientId(string clientId, ValidationContext<GetInvoicePerClientIdFunction> context)
        {
            if (clientId.Length != 8)
            {
                context.AddFailure("ClientID must be 8 characters long");
            }
        }
    }
}