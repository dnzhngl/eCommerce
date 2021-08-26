using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.Description).NotNull().NotEmpty().Length(2, 20);
            RuleFor(b => b.Url).NotNull().NotEmpty().Length(1, 100);
        }
    }
}