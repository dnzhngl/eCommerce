using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Url).NotNull().NotEmpty();
            RuleFor(p => p.BrandId).NotNull();
            RuleFor(p => p.CategoryId).NotNull();
            RuleFor(p => p.CategoryId).NotNull();
        }
    }
}