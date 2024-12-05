using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AuditTrail.Models;
using Orchard.AuditTrail.Services.Models;

namespace Orchard.AuditTrail.ViewModels {
    public class AuditTrailEventSummaryViewModel {
        public AuditTrailEventRecord Record { get; set; }
        public AuditTrailEventDescriptor EventDescriptor { get; set; }
        public AuditTrailCategoryDescriptor CategoryDescriptor { get; set; }
        public dynamic SummaryShape { get; set; }
        public dynamic ActionsShape { get; set; }
    }
}
