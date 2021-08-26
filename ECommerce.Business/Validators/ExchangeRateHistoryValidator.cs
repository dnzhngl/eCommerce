using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class ExchangeRateHistoryValidator : AbstractValidator<ExchangeRateHistory>
    {
        public ExchangeRateHistoryValidator()
        {
            RuleFor(e => e.Currency).NotNull().NotEmpty();
            RuleFor(e => e.ExchangeRate).NotNull();
            RuleFor(e => e.Date).NotNull();
        }
    }
}