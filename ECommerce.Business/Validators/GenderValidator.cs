using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class GenderValidator : AbstractValidator<Gender>
    {
        public GenderValidator()
        {
            RuleFor(g => g.Description).NotNull().NotEmpty();
        }
    }
}