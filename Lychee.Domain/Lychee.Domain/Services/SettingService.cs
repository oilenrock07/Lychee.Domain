using System.Collections.Generic;
using Lychee.Domain.Interfaces;
using Lychee.Entities.Entities;
using Omu.ValueInjecter;

namespace Lychee.Domain.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public virtual ICollection<Setting> GetAllSettings()
        {
            return _settingRepository.GetAllSettings();
        }

        public virtual Setting GetSetting(string key)
        {
            return _settingRepository.GetSetting(key);
        }

        public virtual Setting GetSetting(int id)
        {
            return _settingRepository.GetSetting(id);
        }

        public virtual void UpdateValue(int id, string value)
        {
            var setting = _settingRepository.GetById(id);
            setting.Value = value;

            _settingRepository.Update(setting);
            _settingRepository.SaveChanges();

            _settingRepository.InvalidateCache();
        }

        public virtual void Update(Setting model)
        {
            var setting = _settingRepository.GetById(model.SettingId);
            setting.InjectFrom(model);

            _settingRepository.Update(setting);
            _settingRepository.SaveChanges();

            _settingRepository.InvalidateCache();
        }

        public virtual void Delete(int id)
        {
            var setting = _settingRepository.GetById(id);
            _settingRepository.Delete(setting);
            _settingRepository.SaveChanges();

            _settingRepository.InvalidateCache();
        }
    }
}
