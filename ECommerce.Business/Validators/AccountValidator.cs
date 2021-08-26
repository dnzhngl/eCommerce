using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(a => a.FirstName).NotNull().Length(1,25);
            RuleFor(a => a.LastName).NotNull().Length(1,25);
            RuleFor(a => a.Email).NotNull().EmailAddress();
            RuleFor(a => a.Gsm).NotNull().Length(10);
            
        }
    }
}