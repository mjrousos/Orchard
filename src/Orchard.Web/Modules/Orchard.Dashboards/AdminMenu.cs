using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Navigation;

namespace Orchard.Dashboards {
    public class AdminMenu : Component, INavigationProvider {
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.Add(T("Settings"), settings => settings
                .Add(T("Dashboard"), "16", dashboard => dashboard
                    .Action("Edit", "Dashboard", new { area = "Orchard.Dashboards" })));
        }
    }
}
