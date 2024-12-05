using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using NHibernate.Cfg.Loquacious;

namespace Orchard.Data {
    public interface IDatabaseCacheConfiguration : IDependency {
        void Configure(CacheConfigurationProperties cache);
    }
}
