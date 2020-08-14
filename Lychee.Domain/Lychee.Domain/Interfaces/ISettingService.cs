using System.Collections.Generic;
using Lychee.Entities.Entities;

namespace Lychee.Domain.Interfaces
{
    public interface ISettingService
    {
        Setting GetSetting(string key);
        Setting GetSetting(int id);
        T GetSettingValue<T>(string key);
        T GetSettingValue<T>(string key, T defaultValue);
        ICollection<Setting> GetAllSettings();
        void UpdateValue(int id, string value);
        void Update(Setting model);

        void Delete(int id);
    }
}
