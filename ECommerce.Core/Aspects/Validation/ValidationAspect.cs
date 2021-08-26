using System;
using System.Linq;
using Castle.DynamicProxy;
using EShop.Core.Aspects.Interceptors;
using FluentValidation;


namespace EShop.Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly bool _auto;
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType, bool auto = true)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) throw new Exceptions.ValidationException("Wrong Validation Type");
            Priority = 2;
            _validatorType = validatorType;
            _auto = auto;
        }

        public override void OnBefore(IInvocation invocation)
        {
            var actions = new[] {"Insert", "Update"};
            var action = invocation.Method.Name.Replace("Async", "");
            if (_auto && !actions.ToList().Contains(action)) return;
            var validator = (IValidator) Activator.CreateInstance(_validatorType);
            if (_validatorType.BaseType == null) return;
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities) ValidationTool.Validate(validator, entity);
        }
    }
}