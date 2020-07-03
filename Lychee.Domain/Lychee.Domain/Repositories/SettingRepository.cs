using System;
using System.Collections.Generic;
using System.Linq;
using LazyCache;
using Lychee.Caching.Interfaces;
using Lychee.Domain.Interfaces;
using Lychee.Entities.Entities;
using Lychee.Infrastructure;
using Lychee.Infrastructure.Interfaces;

namespace Lychee.Domain.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly IAppCache _cache;
        private const string _cacheKey = "CACHE:ALL_SETTINGS";


        public SettingRepository(IDatabaseFactory databaseFactory, ICachingFactory cacheFactory) : base(databaseFactory.GetContext())
        {
            _cache = cacheFactory.GetCacheService();
        }

        public virtual ICollection<Setting> GetAllSettings()
        {
            var settings = _cache.GetOrAdd(_cacheKey, GetAll, TimeSpan.FromDays(1));
            return settings.ToList();
        }

        public virtual Setting GetSetting(string key)
        {
            var settings = _cache.GetOrAdd(_cacheKey, GetAll, TimeSpan.FromDays(1));
            return settings.FirstOrDefault(x => x.Key == key);
        }

        public virtual Setting GetSetting(int id)
        {
            var settings = _cache.GetOrAdd(_cacheKey, GetAll, TimeSpan.FromDays(1));
            return settings.FirstOrDefault(x => x.SettingId == id);
        }

        public virtual T GetSettingValue<T>(string key)
        {
            var setting = GetSetting(key);
            if (setting == null)
                return default;

            return (T) Convert.ChangeType(setting.Value, typeof(T));
        }

        public void InvalidateCache()
        {
            _cache.Remove(_cacheKey);
        }
    }
}
