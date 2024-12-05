using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.AuditTrail.ViewModels {
    public class AuditTrailEventSettingsViewModel {
        public string Event { get; set; }
        public LocalizedString Name { get; set; }
        public LocalizedString Description { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsMandatory { get; set; }
    }
}
