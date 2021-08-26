using System;
using System.Linq;
using EShop.Core.Exceptions;
using StackExchange.Redis;

namespace EShop.Core.Plugins.Caching.Redis
{
    public class RedisServer : IRedisServer
    {
        private readonly RedisOption _redisOption;

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisServer(RedisOption redisOption)
        {
            _redisOption = redisOption;
            Connect();
        }
        private void Connect()
        {
            if (string.IsNullOrEmpty(_redisOption.ConnectionString)) throw new NotFoundException("Redis ConnectionString is Empty");
            try
            {
                _connectionMultiplexer = ConnectionMultiplexer.Connect(_redisOption.ConnectionString);
            }
            catch (Exception e)
            {
                throw new ConnectionException(e.Message);
            }

            if (_connectionMultiplexer == null) throw new ConnectionException("Redis Server Not Connected");
        }
        
        public IServer GetServer() => _connectionMultiplexer?.GetServer(_connectionMultiplexer?.GetEndPoints()?.FirstOrDefault());
        
        public IDatabase GetDb(int db) => _connectionMultiplexer?.GetDatabase(db);

        // delete all the keys of the db
        public void FlushDatabase(int db) => _connectionMultiplexer?.GetServer(_redisOption?.ConnectionString)?.FlushDatabase(db);
    }
}