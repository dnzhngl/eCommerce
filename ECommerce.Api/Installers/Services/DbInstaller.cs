using EShop.DataAccess.Contexts.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Api.Installers.Services
{
    public class DbInstaller : IServiceInstaller, IConfigureInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddDbContext<EShopContext>(
                o =>
                {
                    o.UseSqlServer("Server=localhost,1433;Database=EShop;User=sa;Password=Yaren#1998;");
                }, ServiceLifetime.Singleton
        );
    }

        public void InstallConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //dotnet ef database update komutunu kendi çalıştırır
            var context = app.ApplicationServices.GetService<EShopContext>();
            context?.Database?.Migrate();
        }
    }
}