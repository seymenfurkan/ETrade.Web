using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ETrade.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheService
    {
        private readonly IConnectionMultiplexer _multiplexer;
        private readonly IDatabase _cache;

        private TimeSpan ExpireTime => TimeSpan.FromMinutes(10);

        public RedisCacheManager(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
            _cache = multiplexer.GetDatabase();
        }


        public async Task Clear(string key)
        {
            await _cache.KeyDeleteAsync(key);
        }

        public void ClearAll()
        {
            var endPoints = _multiplexer.GetEndPoints(true);
            foreach (var endPoint in endPoints)
            {
                var server = _multiplexer.GetServer(endPoint);
                server.FlushAllDatabases();
            }
        }

        public T GetOrAdd<T>(string key, Func<T> action) where T : class
        {
            var result = _cache.StringGet(key);
            if (result.IsNull)
            {
                result = JsonSerializer.SerializeToUtf8Bytes(action());
                _cache.StringSet(key, result, ExpireTime);
            }
            return JsonSerializer.Deserialize<T>(result);
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action) where T : class
        {
            var result = await _cache.StringGetAsync(key);
            if (result.IsNull)
            {
                result = JsonSerializer.SerializeToUtf8Bytes(action());
                await SetValueAsync(key, result);
            }
            return JsonSerializer.Deserialize<T>(result);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _cache.StringGetAsync(key);
        }

        public async Task<bool> SetValueAsync(string key, string value)
        {
            return await _cache.StringSetAsync(key, value);
        }
    }
}
