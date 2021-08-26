using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class RuleValidator : AbstractValidator<Rule>
    {
        public RuleValidator()
        {
            RuleFor(r => r.Table).NotNull().NotEmpty();
        }
    }
}