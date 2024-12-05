using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Configuration;

namespace Orchard.MultiTenancy.ViewModels {
    public class TenantsIndexViewModel  {
        public IEnumerable<ShellSettings> TenantSettings { get; set; }
    }
}
