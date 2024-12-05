using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Dashboards.Models {
    public class DashboardSiteSettingsPart : ContentPart {
        public int? DefaultDashboardId {
            get { return this.Retrieve(x => x.DefaultDashboardId); }
            set { this.Store(x => x.DefaultDashboardId, value); }
        }
    }
}
