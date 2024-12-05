using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentManagement.Handlers;

namespace Orchard.ContentManagement.Drivers {
    public class DriverResult {
        public virtual void Apply(BuildDisplayContext context) { }
        public virtual void Apply(BuildEditorContext context) { }
        
        public ContentPart ContentPart { get; set; }
        public ContentField ContentField { get; set; }
    }
}
