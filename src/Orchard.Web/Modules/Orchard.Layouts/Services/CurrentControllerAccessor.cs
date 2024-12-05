using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web;
using Orchard.Layouts.Filters;

namespace Orchard.Layouts.Services {
    public class CurrentControllerAccessor : ICurrentControllerAccessor {
        private readonly HttpContextBase _httpContext;
        public CurrentControllerAccessor(HttpContextBase httpContext) {
            _httpContext = httpContext;
        }
        public Controller CurrentController {
            get { return (Controller) _httpContext.Items[ControllerAccessorFilter.CurrentControllerKey]; }
    }
}
