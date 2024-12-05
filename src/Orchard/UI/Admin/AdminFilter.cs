using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Orchard.UI.Admin {
    public class AdminFilter : FilterProvider, IAuthorizationFilter {
        private readonly IAuthorizer _authorizer;
        public AdminFilter(IAuthorizer authorizer) {
            _authorizer = authorizer;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext) {
            if (IsAdmin(filterContext)) {
                Apply(filterContext.RequestContext);
                if (!_authorizer.Authorize(StandardPermissions.AccessAdminPanel, T("Can't access the admin"))) {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
        public static void Apply(RequestContext context) {
            // the value isn't important
            context.HttpContext.Items[typeof(AdminFilter)] = null;
        public static bool IsApplied(RequestContext context) {
            return IsApplied(context.HttpContext);
        public static bool IsApplied(HttpContextBase context) {
            return context.Items.Contains(typeof(AdminFilter));
        private static bool IsAdmin(AuthorizationContext filterContext) {
            if (IsNameAdmin(filterContext) || IsNameAdminProxy(filterContext)) {
                return true;
            var adminAttributes = GetAdminAttributes(filterContext.ActionDescriptor);
            if (adminAttributes != null && adminAttributes.Any()) {
            return false;
        private static bool IsNameAdmin(AuthorizationContext filterContext) {
            return string.Equals(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, "Admin",
                                 StringComparison.OrdinalIgnoreCase);
        private static bool IsNameAdminProxy(AuthorizationContext filterContext) {
            return filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.StartsWith(
                "AdminControllerProxy", StringComparison.InvariantCultureIgnoreCase) &&
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.Length == "AdminControllerProxy".Length + 32;
        private static IEnumerable<AdminAttribute> GetAdminAttributes(ActionDescriptor descriptor) {
            return descriptor.GetCustomAttributes(typeof(AdminAttribute), true)
                .Concat(descriptor.ControllerDescriptor.GetCustomAttributes(typeof(AdminAttribute), true))
                .OfType<AdminAttribute>();
    }
}
