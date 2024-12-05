using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Navigation;

namespace Orchard.DynamicForms {
    public class AdminMenu : Component, INavigationProvider {
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder
                .AddImageSet("dynamicforms")
                .Add(T("Form Submissions"), "8", menu => menu
                    .Add(T("Manage Forms"), "1.0",
                        item => item
                            .Action("Index", "Admin", new { area = "Orchard.DynamicForms" })
                            .Permission(Permissions.ManageForms))
            );
        }
    }
}
