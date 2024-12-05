using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Orchard.AuditTrail.Drivers {
    public class ContentsDriver : ContentPartDriver<ContentPart> {
        protected override DriverResult Display(ContentPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Contents_AuditTrail_SummaryAdmin", () => shapeHelper.Parts_Contents_AuditTrail_SummaryAdmin());
        }
    }
}
