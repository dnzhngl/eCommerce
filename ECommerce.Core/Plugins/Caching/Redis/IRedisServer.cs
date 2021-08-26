using StackExchange.Redis;

namespace EShop.Core.Plugins.Caching.Redis
{
    public interface IRedisServer
    {
        /// <summary>
        /// Get Server
        /// </summary>
        /// <returns></returns>
        IServer GetServer();
        
        /// <summary>
        /// Get Db By Id
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        IDatabase GetDb(int db);
        
        /// <summary>
        /// FlushDb By Id
        /// </summary>
        /// <param name="db"></param>
        void FlushDatabase(int db);
        
    }
}