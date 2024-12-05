using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.AuditTrail.Services.Models {
    public class DisplayFilterContext {
        public DisplayFilterContext(IShapeFactory shapeFactory, Filters filters, dynamic filterDisplay) {
            ShapeFactory = shapeFactory;
            Filters = filters;
            FilterDisplay = filterDisplay;
        }
        public dynamic ShapeFactory { get; set; }
        public Filters Filters { get; set; }
        public dynamic FilterDisplay { get; set; }
    }
}
