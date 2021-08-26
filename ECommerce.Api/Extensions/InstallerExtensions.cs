using System;
using System.Linq;
using EShop.Api.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Api.Extensions
{
    public static class InstallerExtensions
    {

        public static void InstallAllService(this IServiceCollection services)
        {
            
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IServiceInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .OrderBy(x => x.Name).Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();
            installers.ForEach(x=>x.InstallService(services));
            
        }
        
        public static void InstallAllConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IConfigureInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .OrderBy(x => x.Name).Select(Activator.CreateInstance).Cast<IConfigureInstaller>().ToList();
            installers.ForEach(x=>x.InstallConfigure(app,env));
            
        }
    }
}