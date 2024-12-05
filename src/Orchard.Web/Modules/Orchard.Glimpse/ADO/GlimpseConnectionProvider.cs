using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;
using NHibernate.Connection;
using NHibernate.Driver;

namespace Orchard.Glimpse.ADO {
    public class GlimpseConnectionProvider : DriverConnectionProvider, IConnectionProvider {
        public new IDriver Driver {
            get {
                var originalDriver = base.Driver;
                if (HttpContext.Current == null || originalDriver is GlimpseDriver) {
                    return originalDriver;
                }
                return new GlimpseDriver(originalDriver);
            }
        }
    }
}
