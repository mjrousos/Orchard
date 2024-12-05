using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Linq;
using System.Web.Routing;

namespace Orchard.Themes {
    public class ThemeFilter : FilterProvider, IActionFilter, IResultFilter {
        public void OnActionExecuting(ActionExecutingContext filterContext) {
            var attribute = GetThemedAttribute(filterContext.ActionDescriptor);
            if (AdminFilter.IsApplied(filterContext.RequestContext)) {
                // admin are themed by default
                if (attribute == null || attribute.Enabled) {
                    Apply(filterContext.RequestContext);
                }
            }
            else {
                // non-admin are explicitly themed
                // Don't layout the result if it's not an Admin controller and it's disabled
                if (attribute != null && attribute.Enabled) {
        }
        public void OnActionExecuted(ActionExecutedContext filterContext) {}
        public void OnResultExecuting(ResultExecutingContext filterContext) {
        public void OnResultExecuted(ResultExecutedContext filterContext) {}
        public static void Apply(RequestContext context) {
            // the value isn't important
            context.HttpContext.Items[typeof(ThemeFilter)] = null;
        public static void Disable(RequestContext context) {
            context.HttpContext.Items.Remove(typeof(ThemeFilter));
        public static bool IsApplied(RequestContext context) {
            return context.HttpContext.Items.Contains(typeof (ThemeFilter));
        private static ThemedAttribute GetThemedAttribute(ActionDescriptor descriptor) {
            return descriptor.GetCustomAttributes(typeof (ThemedAttribute), true)
                .Concat(descriptor.ControllerDescriptor.GetCustomAttributes(typeof (ThemedAttribute), true))
                .OfType<ThemedAttribute>()
                .FirstOrDefault();
    }
}
