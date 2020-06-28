using System.Collections.Generic;
using Lychee.Entities.Entities;
using Lychee.Infrastructure.Interfaces;

namespace Lychee.Domain.Interfaces
{
    public interface ISettingRepository : IRepository<Setting>
    {
        ICollection<Setting> GetAllSettings();
        Setting GetSetting(string key);
        T GetSettingValue<T>(string key);
    }
}
