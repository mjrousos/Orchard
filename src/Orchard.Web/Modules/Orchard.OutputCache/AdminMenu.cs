using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Localization;
using Orchard.UI.Navigation;

namespace Orchard.OutputCache {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder
                .Add(T("Settings"), menu => menu
                    .Add(T("Cache"), "10.0", subMenu => subMenu.Action("Index", "Admin", new { area = "Orchard.OutputCache" }).Permission(StandardPermissions.SiteOwner)
                        .Add(T("Settings"), "10.0", item => item.Action("Index", "Admin", new { area = "Orchard.OutputCache" }).Permission(StandardPermissions.SiteOwner).LocalNav())
                        .Add(T("Statistics"), "10.0", item => item.Action("Index", "Statistics", new { area = "Orchard.OutputCache" }).Permission(StandardPermissions.SiteOwner).LocalNav())
                    ));
        }
    }
}
