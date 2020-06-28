using System;
using System.Collections.Generic;
using System.Linq;
using Lychee.Domain.Interfaces;
using Lychee.Entities.Entities;
using Lychee.Infrastructure;
using Lychee.Infrastructure.Interfaces;

namespace Lychee.Domain.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        protected virtual List<Setting> _settings { get; set; }

        public SettingRepository(IDatabaseFactory databaseFactory) : base(databaseFactory.GetContext())
        {

        }

        public virtual ICollection<Setting> GetAllSettings()
        {
            if (_settings != null) return _settings;

            _settings = GetAll().ToList();
            return _settings;
        }

        public virtual Setting GetSetting(string key)
        {
            if (_settings == null)
                GetAllSettings();

            return _settings.FirstOrDefault(x => x.Key == key);
        }

        public virtual T GetSettingValue<T>(string key)
        {
            if (_settings == null)
                GetAllSettings();

            var setting = GetSetting(key);
            if (setting == null)
                return default;

            return (T) Convert.ChangeType(setting.Value, typeof(T));
        }
    }
}
