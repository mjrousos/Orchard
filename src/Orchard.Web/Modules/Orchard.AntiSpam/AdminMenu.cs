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

namespace Orchard.AntiSpam {
    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder.Add(T("Spam"), "4.1",
                        menu => menu
                                    .Add(T("Manage Spam"), "1.0", item => item.Action("Index", "Admin", new { area = "Orchard.AntiSpam" }).Permission(Permissions.ManageAntiSpam))
                                    );
        }
    }
}
