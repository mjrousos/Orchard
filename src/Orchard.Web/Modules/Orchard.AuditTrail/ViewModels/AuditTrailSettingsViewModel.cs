using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.AuditTrail.ViewModels {
    public class AuditTrailSettingsViewModel {
        public IList<AuditTrailCategorySettingsViewModel> Categories { get; set; }
        public bool EnableClientIpAddressLogging { get; set; }
    }
}
