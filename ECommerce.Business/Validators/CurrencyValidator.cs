using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(c => c.Symbol).NotNull().NotEmpty();
            RuleFor(c => c.CurrencyCode).NotNull().NotEmpty();
            RuleFor(c => c.ExchangeRate).NotNull();
        }
    }
}