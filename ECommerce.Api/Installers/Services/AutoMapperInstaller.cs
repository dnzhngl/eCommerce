using AutoMapper;
using ECommerce.Business.Installers.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Installers.Services
{
    public class AutoMapperInstaller : IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddSingleton(
                new MapperConfiguration(x =>
                        x.AddProfile(new AutoMapperProfile()))
                    .CreateMapper());
        }
    }
}