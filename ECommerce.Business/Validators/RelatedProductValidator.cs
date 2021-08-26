using eCommerce.DataAccess.Entities;
using FluentValidation;

namespace ECommerce.Business.Validators
{
    public class RelatedProductValidator : AbstractValidator<RelatedProduct>
    {
        public RelatedProductValidator()
        {
        }
    }
}