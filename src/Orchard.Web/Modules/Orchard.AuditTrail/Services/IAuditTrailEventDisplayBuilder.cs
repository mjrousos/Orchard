using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.AuditTrail.Models;

namespace Orchard.AuditTrail.Services {
    public interface IAuditTrailEventDisplayBuilder : IDependency {
        dynamic BuildDisplay(AuditTrailEventRecord record, string displayType);
        dynamic BuildActions(AuditTrailEventRecord record, string displayType);
    }
}
