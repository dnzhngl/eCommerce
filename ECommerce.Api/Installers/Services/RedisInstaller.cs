using ECommerce.Core.Plugins.Caching;
using ECommerce.Core.Plugins.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Installers.Services
{
    public class RedisInstaller:IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddSingleton<IRedisServer, RedisServer>();
            services.AddSingleton<ICacheService, RedisCacheService>();
            var opt = new RedisOption
            {
                InstanceName = "Ecommerce.Api",
                ConnectionString = "localhost:6376,ssl=False",
                AbsoluteExpiration = 60
            };
            services.AddSingleton(opt);
        }
    }
}