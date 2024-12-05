using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Dashboards.Models;

namespace Orchard.Dashboards.Handlers {
    public class DashboardSiteSettingsPartHandler : ContentHandler {
        public DashboardSiteSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<DashboardSiteSettingsPart>("Site"));
        }
    }
}
