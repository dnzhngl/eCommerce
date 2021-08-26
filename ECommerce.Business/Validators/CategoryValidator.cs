using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().Length(2, 25);
            RuleFor(c => c.Url).NotNull().NotEmpty().Length(1, 100);
        }
    }
}