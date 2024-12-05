using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web;
using Orchard.ContentManagement.Drivers;
using Orchard.Themes.Models;

namespace Orchard.Themes.Drivers {
    public class DisableThemePartDriver : ContentPartDriver<DisableThemePart> {
        private readonly HttpContextBase _httpContext;
        public DisableThemePartDriver(HttpContextBase httpContext) {
            _httpContext = httpContext;
        }
        protected override DriverResult Display(DisableThemePart part, string displayType, dynamic shapeHelper) {
            if (AdminFilter.IsApplied(_httpContext.Request.RequestContext)) {
                return null;
            }
            return ContentShape("Parts_DisableTheme", () => {
                ThemeFilter.Disable(_httpContext.Request.RequestContext);
            });
    }
}
