using EShop.Core.Plugins.Caching;
using EShop.Core.Plugins.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Api.Installers.Services
{
    public class RedisInstaller:IServiceInstaller
    {
        public void InstallService(IServiceCollection services)
        {
            services.AddSingleton<IRedisServer, RedisServer>();
            services.AddSingleton<ICacheService, RedisCacheService>();
            var opt = new RedisOption
            {
                InstanceName = "EShop.Api",
                ConnectionString = "localhost:6376,ssl=False",
                AbsoluteExpiration = 60
            };
            services.AddSingleton(opt);
        }
    }
}