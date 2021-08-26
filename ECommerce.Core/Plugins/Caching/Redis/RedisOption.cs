namespace EShop.Core.Plugins.Caching.Redis
{
    public class RedisOption
    {
        public string InstanceName { get; set; } 
        public string ConnectionString { get; set; }
        public int AbsoluteExpiration { get; set; } 
    }
}