using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using EShop.Core.Aspects.Interceptors;
using Module = Autofac.Module;

namespace EShop.Business.Installers
{
    public class AutofacBusinessModule  :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                    
                }).SingleInstance();
        }
    }
}