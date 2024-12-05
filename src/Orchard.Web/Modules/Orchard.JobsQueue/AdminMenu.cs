using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.UI.Navigation;

namespace Orchard.JobsQueue {
    [OrchardFeature("Orchard.JobsQueue.UI")]
    public class AdminMenu : Component, INavigationProvider {
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder
                .AddImageSet("jobsqueue")
                .Add(T("Jobs Queue"), "15.0", item => {
                    item.Permission(StandardPermissions.SiteOwner);
                    item.Action("List", "Admin", new { area = "Orchard.JobsQueue" });
                    item.LinkToFirstChild(false);
                });
        }
    }
}
