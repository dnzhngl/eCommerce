using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EShop.Core.Extensions
{
    public static class JsonExtensions
    {
        // stringe çeviren
        public static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static T FromJson<T>(this string source) where T : new()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(source);
            }
            catch 
            {
                return new T();
            }
        }
    }
}