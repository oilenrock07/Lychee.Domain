using System.Collections.Generic;
using Lychee.Entities.Entities;

namespace Lychee.Domain.Interfaces
{
    public interface ISettingRepository
    {
        ICollection<Setting> GetAllSettings();
        Setting GetSetting(string key);
        T GetSettingValue<T>(string key);
    }
}
