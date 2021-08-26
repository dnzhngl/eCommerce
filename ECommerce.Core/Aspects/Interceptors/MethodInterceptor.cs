using System;
using Castle.DynamicProxy;
using EShop.Core.Exceptions;

namespace EShop.Core.Aspects.Interceptors
{
    public class MethodInterception:MethodInterceptionBase
    {
        public virtual void OnBefore(IInvocation invocation)
        {
            
        }

        public virtual void OnAfter(IInvocation invocation)
        {
            
        }

        public virtual void OnException(IInvocation invocation)
        {
            
        }

        public virtual void OnSuccess(IInvocation invocation)
        {
            
        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation);
                throw new AspectException(e.Message);
            }
            finally
            {
                if (isSuccess) OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
    }
}