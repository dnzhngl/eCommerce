using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class ProductGroupLineValidator : AbstractValidator<ProductGroupLine>
    {
        public ProductGroupLineValidator()
        {
        }
    }
}