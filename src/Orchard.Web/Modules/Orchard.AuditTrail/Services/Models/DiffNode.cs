using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.AuditTrail.Services.Models {
    public class DiffNode {
        public DiffType Type { get; set; }
        public string Context { get; set; }
        public string Previous { get; set; }
        public string Current { get; set; }
    }
}
