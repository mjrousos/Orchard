using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web;

namespace Orchard.Mvc.Extensions {
    public static class HttpContextBaseExtensions {
        public static bool IsBackgroundContext(this HttpContextBase httpContextBase) {
            return httpContextBase == null || httpContextBase is MvcModule.HttpContextPlaceholder;
        }
    }
    public static class HttpContextExtensions {
        public static bool IsBackgroundHttpContext(this HttpContext httpContext) {
            return HttpContextAccessor.IsBackgroundHttpContext(httpContext);
}
