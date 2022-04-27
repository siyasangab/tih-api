using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace GitAssessment.Services.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task<T> Get<T>(string key)
        {
            var value = await distributedCache.GetStringAsync(key);

            if (value != null)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return default;
        }

        public async Task<T> Set<T>(string key, T value)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value), options);

            return value;
        }
    }
}
