using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.AuditTrail.Models {

    /// <summary>
    /// The created audit trail event result
    /// </summary>
    public class AuditTrailEventRecordResult {
        /// <summary>
        /// The created <see cref="AuditTrailEventRecord"/> 
        /// </summary>
        public AuditTrailEventRecord Record { get; set; }
        /// Determines whether AuditTrailEventRecordResult is disabled for <see cref="AuditTrailEventRecord"/> .
        public bool IsDisabled { get; set; }
    }
}
