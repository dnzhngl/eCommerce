using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class AccountAddressValidator : AbstractValidator<AccountAddress>
    {
        public AccountAddressValidator()
        {
            RuleFor(a => a.Address).NotNull().NotEmpty().Length(3, 250);
            RuleFor(a => a.AccountId).NotNull();
            RuleFor(a => a.AddressType).NotNull().NotEmpty();
        }
    }
}