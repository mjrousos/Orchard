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

namespace Orchard.AuditTrail.Menus {
    [OrchardFeature("Orchard.AuditTrail.RecycleBin")]
    public class RecycleBinAdminMenu : Component, INavigationProvider {
        public string MenuName { get { return "admin"; } }
        public void GetNavigation(NavigationBuilder builder) {
            builder
                .Add(T("Audit Trail"), "12", auditTrail => auditTrail
                    .Add(T("Recycle Bin"), "2", history => history
                        .Action("Index", "RecycleBin", new { area = "Orchard.AuditTrail" })
                        .LocalNav()));
        }
    }
}
