using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class UserGroupValidator : AbstractValidator<UserGroup>
    {
        public UserGroupValidator()
        {
            RuleFor(u => u.Description).NotNull().NotEmpty();
        }
    }
}