using eCommerce.DataAccess.Contexts.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Installers.Services
{
    public class DbInstaller : IServiceInstaller, IConfigureInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddDbContext<ECommerceContext>(
                o =>
                {
                    o.UseSqlServer("Server=localhost,1433;Database=ECommerce;User=SA;Password=123456a@;");
                }, ServiceLifetime.Singleton
        );
    }

        public void InstallConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //dotnet ef database update komutunu kendi çalıştırır
            var context = app.ApplicationServices.GetService<ECommerceContext>();
            context?.Database?.Migrate();
        }
    }
}