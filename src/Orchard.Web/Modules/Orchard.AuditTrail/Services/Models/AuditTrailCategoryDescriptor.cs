using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.AuditTrail.Models;

namespace Orchard.AuditTrail.Services.Models {
    public class AuditTrailCategoryDescriptor {
        public string Category { get; set; }
        public LocalizedString Name { get; set; }
        public IEnumerable<AuditTrailEventDescriptor> Events { get; set; }
    }
}
