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

namespace Orchard.Indexing {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.Add(T("Settings"),
                menu => menu.Add(T("Indexes"), "5", item => item.Action("Index", "Admin", new {area = "Orchard.Indexing"})
                        .Permission(StandardPermissions.SiteOwner)));
        }
    }
}
