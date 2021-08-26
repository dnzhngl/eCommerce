using EShop.Business.Abstract;
using EShop.Business.Concrete;
using EShop.Business.Repositories;
using EShop.Core.Plugins.Authentication.Jwt;
using EShop.DataAccess.Repositories;
using EShop.DataAccess.Repositories.EF;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Api.Installers.Services
{
    public class InterfaceInstaller:IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddSingleton(typeof(IServiceRepository<>), typeof(ServiceRepository<,>));
            services.AddSingleton<IGenderService, GenderService>();
            services.AddSingleton<IUserGroupService, UserGroupService>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            

        }
    }
}