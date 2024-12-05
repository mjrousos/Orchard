using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.AuditTrail.Services.Models;

namespace Orchard.AuditTrail.ViewModels {
    public class AuditTrailViewModel {
        public dynamic FilterDisplay { get; set; }
        public AuditTrailOrderBy OrderBy { get; set; }
        public IEnumerable<AuditTrailEventSummaryViewModel> Records { get; set; }
        public dynamic List { get; set; }
        public dynamic Pager { get; set; }
    }
}
