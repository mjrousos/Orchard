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

namespace Orchard.Users {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.AddImageSet("users")
                .Add(T("Users"), "11",
                    menu => menu.Action("Index", "Admin", new { area = "Orchard.Users" })
                        .Add(T("Users"), "1.0", item => item.Action("Index", "Admin", new { area = "Orchard.Users" })
                            .LocalNav().Permission(Permissions.ViewUsers)));
        }
    }
}
