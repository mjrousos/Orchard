using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.Logging;

namespace Orchard.Security {
    public class SecurityFilter : FilterProvider, IExceptionFilter, IAuthorizationFilter {
        private readonly IAuthorizer _authorizer;
        public SecurityFilter(IAuthorizer authorizer) {
            _authorizer = authorizer;
            Logger = NullLogger.Instance;
        }
        public ILogger Logger { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext) {
            var accessFrontEnd = filterContext.ActionDescriptor.GetCustomAttributes(typeof (AlwaysAccessibleAttribute), true).Any();
            if (!accessFrontEnd && filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.GetCustomAttributes(typeof(AlwaysAccessibleAttribute), true).Any()) {
                accessFrontEnd = true;
            }
            if (!AdminFilter.IsApplied(filterContext.RequestContext) && !accessFrontEnd && !_authorizer.Authorize(StandardPermissions.AccessFrontEnd)) {
                filterContext.Result = new HttpUnauthorizedResult();
        public void OnException(ExceptionContext filterContext) {
            if (!(filterContext.Exception is OrchardSecurityException))
                return;
            try {
                Logger.Information(filterContext.Exception, "Security exception converted to access denied result");
            catch {
                //a logger exception can't be allowed to interrupt this process
            filterContext.Result = new HttpUnauthorizedResult();
            filterContext.ExceptionHandled = true;
    }
}
