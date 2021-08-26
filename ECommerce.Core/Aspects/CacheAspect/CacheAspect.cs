using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using EShop.Core.Aspects.Interceptors;
using EShop.Core.Plugins.Caching;
using EShop.Core.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Core.Aspects.CacheAspect
{
    public class CacheAspect:MethodInterception
    {
        private readonly ICacheService _cacheService;
        private readonly int _db;
        private readonly int? _duration;
        private readonly string _pattern;

        public CacheAspect(string pattern = "", int db = 0, int duration = 60)
        {
            _pattern =pattern;
            _duration =duration;
            _db = db;
            Priority = 3;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }
        
        public override void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget;
            var key = Key(invocation);
            //Gender.GetAll(100,1,Null,Id,False)
            
            if (_cacheService.AnyAsync(key).Result)
            {
                try
                {
                    var resultType = invocation.Method.ReturnType.GenericTypeArguments.FirstOrDefault();
                    var returnValue = _cacheService.GetAsync(key).Result;

                    dynamic temp = JsonSerializer.Deserialize(returnValue, resultType!);
                    invocation.ReturnValue = Task.FromResult(temp);
                    return;
                }
                catch
                {
                    //
                }
            }

            invocation.Proceed();
            var isAsync = method.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) != null;
            if (isAsync && typeof(Task).IsAssignableFrom(method.ReturnType))
            {
                invocation.ReturnValue = InterceptAsync((dynamic) invocation.ReturnValue, key);
            }
        }

        private static async Task InterceptAsync(Task task, string key)
        {
            await task.ConfigureAwait(false);
        }

        private async Task<T> InterceptAsync<T>(Task<T> task, string key)
        {
            var result = await task.ConfigureAwait(false);
            var data = JsonSerializer.Serialize(result);
            await _cacheService.SetAsync(key, data, _duration, _db);
            return result;
        }

        private string Key(IInvocation invocation)
        {
            var methodName = string.IsNullOrEmpty(_pattern)
                ? $"{invocation.InvocationTarget.GetType().Name.Replace("Service", "")}.{invocation.Method.Name.Replace("Async", "")}"
                : _pattern;

            var arguments = invocation.Arguments.ToList();
            var parameters = "";
            for (var i = 0; i < arguments.Count; i++)
            {
                var arg = arguments[i];
                if (parameters != "") parameters += ",";
                if (arg.GetType().IsClass)
                {
                    parameters += GetProperties(arg);
                }
                else
                {
                    parameters += arg.ToString();
                }
            }

            return $"{methodName}({parameters})";
        }

        private static string GetProperties(object arg)
        {
            //100,1,Null,Id,False
            try
            {
                return arg == null
                    ? "Null"
                    : arg.GetType().GetProperties().Select(x => x.GetValue(arg) ?? "Null")
                        .Aggregate("", (current, value) => current + (current == "" ? "" : ",") + $"{value}");
            }
            catch
            {
                return arg?.ToString()?.Replace("/", "") ?? "Null";
            }
        }
    }
}