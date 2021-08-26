using ECommerce.Business.Abstract;
using ECommerce.Business.Concrete;
using ECommerce.Business.Repositories;
using eCommerce.DataAccess.Repositories;
using eCommerce.DataAccess.Repositories.EF;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Installers.Services
{
    public class InterfaceInstaller:IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddSingleton(typeof(IServiceRepository<>), typeof(ServiceRepository<,>));
            
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IAccountAddressService, AccountAddressService>();
            services.AddSingleton<IBrandService, BrandService>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICityService, CityService>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<ICurrencyService, CurrencyService>();
            services.AddSingleton<IDistrictService, DistrictService>();
            services.AddSingleton<IExchangeRateHistoryService, ExchangeRateHistoryService>();
            services.AddSingleton<IFavoriteProductService, FavoriteProductService>();
            services.AddSingleton<IGenderService, GenderService>();
            services.AddSingleton<IProductGroupLineService, ProductGroupLineService>();
            services.AddSingleton<IProductGroupService, ProductGroupService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IRelatedProductService, RelatedProductService>();
            services.AddSingleton<IRoleService, RoleService>();
            services.AddSingleton<IRuleService, RuleService>();
            services.AddSingleton<ISettingService, SettingService>();
            services.AddSingleton<IUserGroupService, UserGroupService>();

        }
    }
}