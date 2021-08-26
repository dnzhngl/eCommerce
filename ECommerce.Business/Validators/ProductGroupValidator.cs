using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class ProductGroupValidator : AbstractValidator<ProductGroup>
    {
        public ProductGroupValidator()
        {
            RuleFor(p => p.Description).NotNull().NotEmpty();
        }
    }
}