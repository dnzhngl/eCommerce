using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().Length(2, 25);
            RuleFor(c => c.CountryCode).NotNull().NotEmpty();
        }
    }
}