using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web.Routing;
using Orchard.DisplayManagement.Implementation;
using Orchard.Environment.Extensions;

namespace Orchard.Localization.Services {
    [OrchardFeature("Orchard.Localization.CultureSelector")]
    public class AdminDirectionalityFactory : ShapeDisplayEvents {
        private readonly WorkContext _workContext;
        public AdminDirectionalityFactory(
            IWorkContextAccessor workContextAccessor) {
            _workContext = workContextAccessor.GetContext();
        }
        private bool IsActivable() {
            // activate on admin screen only
            if (AdminFilter.IsApplied(new RequestContext(_workContext.HttpContext, new RouteData())))
                return true;
            return false;
        public override void Displaying(ShapeDisplayingContext context) {
            context.ShapeMetadata.OnDisplaying(displayedContext => {
                if (!IsActivable()) {
                    return;
                }
                if (context.ShapeMetadata.Type != "EditorTemplate" &&
                    context.ShapeMetadata.Type != "Zone")
                ContentItem contentItem = context.Shape.ContentItem;
                // if not, check for ContentPart 
                if (contentItem == null) {
                    ContentPart contentPart = context.Shape.ContentPart;
                    if (contentPart != null) {
                        contentItem = contentPart.ContentItem;
                    }
                var className = "content-" + _workContext.GetTextDirection(contentItem);
                if (!_workContext.Layout.Content.Classes.Contains(className))
                    _workContext.Layout.Content.Classes.Add(className);
            });
    }
}
