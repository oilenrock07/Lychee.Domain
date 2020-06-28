using Lychee.Domain.Interfaces;
using Lychee.Domain.Repositories;
using Lychee.Domain.Services;
using SimpleInjector;

namespace Lychee.Domain
{
    public static class LycheeDomainServiceModule
    {
        public static void RegisterLycheeDomainServiceModule(this Container container, Lifestyle lifestyle = null)
        {
            if (lifestyle == null)
                lifestyle = Lifestyle.Scoped;

            container.Register<ISettingRepository, SettingRepository>(lifestyle);
            container.Register<ISettingService, SettingService>(lifestyle);
        }
    }
}
