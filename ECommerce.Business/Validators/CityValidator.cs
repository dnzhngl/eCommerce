using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().Length(1, 25);
            RuleFor(c => c.LicencePlate).NotEmpty().NotNull();
        }
    }
}