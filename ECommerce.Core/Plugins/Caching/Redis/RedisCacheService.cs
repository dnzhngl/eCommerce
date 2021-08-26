using System;
using System.Linq;
using System.Threading.Tasks;
using EShop.Core.Extensions;

namespace EShop.Core.Plugins.Caching.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly IRedisServer _server;
        private readonly RedisOption _option;

        public RedisCacheService(IRedisServer server, RedisOption option)
        {
            _server = server;
            _option = option;
        }


        public async Task<bool> AnyAsync(string key, int db = 0)
        {
            var database = _server.GetDb(db);
            var result = await database.StringGetAsync($"{_option.InstanceName}.{key}");
            return result.HasValue;
        }

        public async Task<T> GetAsync<T>(string key, int db = 0) where T : new()
        {
            var database = _server.GetDb(db);
            var result = await database.StringGetAsync($"{_option.InstanceName}.{key}");
            
            return !result.HasValue ? new T() : result.ToString().FromJson<T>();
            
        }

        public async Task<string> GetAsync(string key, int db = 0)
        {
            var database = _server.GetDb(db);
            var result = await database.StringGetAsync($"{_option.InstanceName}.{key}");
            return !result.HasValue ? "" : result.ToString();
        }

        public async Task SetAsync(string key, string data, int? minute = null, int db = 0)
        {
            minute ??= _option.AbsoluteExpiration;
            var database = _server.GetDb(db);
            await RemoveAsync(key, db);
            await database.StringSetAsync(
                $"{_option.InstanceName}.{key}", 
                data, 
                TimeSpan.FromMinutes((int)minute)
                );
        }

        public async Task RemoveAsync(string key, int db = 0)
        {
            var database = _server.GetDb(db);
            if (await AnyAsync(key,db))
            {
                await database.KeyDeleteAsync($"{_option.InstanceName}.{key}");
            }
        }

        public async Task RemoveByPatternAsync(string pattern, int db = 0)
        {
            var database = _server.GetDb(db);
            var server = _server.GetServer();
            var keys = server.Keys(pattern: $"{_option.InstanceName}.{pattern}*", database: db).ToList();
            foreach (var key in keys)
            {
                await database.KeyDeleteAsync(key);
            }

            await database.KeyDeleteAsync($"{_option.InstanceName}.{pattern}");
        }

        public void Clear()
        {
            for (var i = 0; i <= 15; i++)
            {
                _server.FlushDatabase(i);
            }
        }
    }
}