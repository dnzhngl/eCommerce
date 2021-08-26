using Castle.DynamicProxy;
using EShop.Core.Aspects.Interceptors;
using EShop.Core.Plugins.Caching;
using EShop.Core.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Core.Aspects.CacheAspect
{
    public class RemoveCacheAspect : MethodInterception
    {
        private readonly ICacheService _cacheService;
        private readonly int _db;

        private readonly string _pattern;

        public RemoveCacheAspect(string pattern = "", int db = 0)
        {
            _db = db;
            _pattern = pattern;
            Priority = 10;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void OnSuccess(IInvocation invocation)
        {
            var key = _pattern == "" ? $"{invocation.InvocationTarget.GetType().Name.Replace("Service", "")}" : _pattern;
            if (invocation.Method.ReflectedType == null) return;
            _cacheService.RemoveByPatternAsync(key, _db);
        }
    }
}