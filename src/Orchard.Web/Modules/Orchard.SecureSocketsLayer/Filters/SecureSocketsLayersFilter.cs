using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Specialized;
using Orchard.SecureSocketsLayer.Services;

namespace Orchard.SecureSocketsLayer.Filters {
    public class SecureSocketsLayersFilter : FilterProvider, IActionFilter {
        private readonly ISecureSocketsLayerService _sslService;
        private readonly IOrchardServices _orchardServices;
        public SecureSocketsLayersFilter(ISecureSocketsLayerService sslService, IOrchardServices orchardServices) {
            _sslService = sslService;
            _orchardServices = orchardServices;
        }
        public Localizer T { get; set; }
        public void OnActionExecuted(ActionExecutedContext filterContext) {
        public void OnActionExecuting(ActionExecutingContext filterContext) {
            var settings = _sslService.GetSettings();
            if (filterContext.IsChildAction || !settings.Enabled) {
                return;
            }
            var user = filterContext.HttpContext.User;
            var secure =
                (user != null && user.Identity.IsAuthenticated) ||
                _sslService.ShouldBeSecure(filterContext);
            var usePermanentRedirect = settings.UsePermanentRedirect;
            var request = filterContext.HttpContext.Request;
            // redirect to a secured connection ?
            if (secure && !request.IsSecureConnection) {
                var secureActionUrl = AppendQueryString(
                    request.QueryString,
                    _sslService.SecureActionUrl(
                        filterContext.ActionDescriptor.ActionName,
                        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                        filterContext.RequestContext.RouteData.Values));
                filterContext.Result = new RedirectResult(secureActionUrl, usePermanentRedirect);
            // non auth page on a secure canal
            // nb: needed as the ReturnUrl for LogOn doesn't force the scheme to http, and reuses the current one
            // Also don't force http on ajax requests.
            if (!secure && request.IsSecureConnection && !request.IsAjaxRequest()) {
                var insecureActionUrl = AppendQueryString(
                    _sslService.InsecureActionUrl(
                filterContext.Result = new RedirectResult(insecureActionUrl, usePermanentRedirect);
        private static string AppendQueryString(NameValueCollection queryString, string url) {
            if (queryString.Count > 0) {
                url += '?' + queryString.ToString();
            return url;
    }
}
