using System.Collections.Generic;
using Lychee.Entities.Entities;

namespace Lychee.Domain.Interfaces
{
    public interface ISettingService
    {
        Setting GetSetting(string key);
        Setting GetSetting(int id);
        ICollection<Setting> GetAllSettings();
        void UpdateValue(int id, string value);
        void Update(Setting model);

        void Delete(int id);
    }
}
