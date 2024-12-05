using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Navigation;

namespace Orchard.Templates {
    public class AdminMenu : Component, INavigationProvider {
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder
                .AddImageSet("templates")
                .Add(T("Templates"), "5.0", item => item.Action("List", "Admin", new { area = "Orchard.Templates", id = "" }).Permission(Permissions.ManageTemplates));
        }
    }
}
