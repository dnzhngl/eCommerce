using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class SettingValidator : AbstractValidator<Setting>
    {
        public SettingValidator()
        {
            RuleFor(r => r.Key).NotNull().NotEmpty();
            RuleFor(r => r.Value).NotNull().NotEmpty();
        }
    }
}