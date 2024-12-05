using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using NHibernate.Cfg;

namespace Orchard.Data {
    public interface ISessionConfigurationCache {
        Configuration GetConfiguration(Func<Configuration> builder);
    }
}
