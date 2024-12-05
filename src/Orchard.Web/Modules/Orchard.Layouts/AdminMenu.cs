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

namespace Orchard.Layouts {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder
                .AddImageSet("layouts")
                .Add(T("Layouts"), "8.5", layouts => layouts
                    .Action("List", "Admin", new {id = "Layout", area = "Contents"}).Permission(Permissions.ManageLayouts)
                    .LinkToFirstChild(false)
                    .Add(T("Elements"), "1", elements => elements.Action("Index", "BlueprintAdmin", new {area = "Orchard.Layouts"}).Permission(Permissions.ManageLayouts)));
        }
    }
}
