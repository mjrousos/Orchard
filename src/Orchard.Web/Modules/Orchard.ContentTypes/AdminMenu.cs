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

namespace Orchard.ContentTypes {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.AddImageSet("contenttypes");
            builder.Add(T("Content Definition"), "1.4.1", menu => {
                menu.LinkToFirstChild(true);
                menu.Add(T("Content Types"), "1", item => item.Action("Index", "Admin", new { area = "Orchard.ContentTypes" }).Permission(Permissions.ViewContentTypes).LocalNav());
                menu.Add(T("Content Parts"), "2", item => item.Action("ListParts", "Admin", new { area = "Orchard.ContentTypes" }).Permission(Permissions.ViewContentTypes).LocalNav());
            });
        }
    }
}
