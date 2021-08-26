using System.Linq;
using EShop.Core.Extensions;
using EShop.Core.Models;
using FluentValidation;

namespace EShop.Core.Aspects.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object obj)
        {
            var result = validator.Validate(obj);
            if (result.IsValid) return;
            var notContains = new[] {"ComparisonProperty", "ComparisonValue"};
            var errors = result.Errors.Select(x => new ValidationErrorResponse
            {
                ErrorCode = x.ErrorCode,
                ErrorMessage=x.ErrorMessage,
                PlaceHolderValues = x.FormattedMessagePlaceholderValues.Where(y=>!notContains.Contains(y.Key)).ToList()
                
            }).ToList();
            throw new Exceptions.ValidationException(errors.ToJson());
        }
    }

    
}