using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class FavoriteProductValidator : AbstractValidator<FavoriteProduct>
    {
        public FavoriteProductValidator()
        {
            RuleFor(f => f.AccountId).NotNull();
            RuleFor(f => f.ProductId).NotNull();
        }
    }
}