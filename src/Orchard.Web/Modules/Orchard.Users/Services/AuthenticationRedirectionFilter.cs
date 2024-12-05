using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace Orchard.Users.Services {
    /// <summary>
    /// This class is responsible for redirecting the user to the authentication page 
    /// of the current tenant.
    /// </summary>
    public class AuthenticationRedirectionFilter : FilterProvider, IAuthenticationFilter {
        public void OnAuthentication(AuthenticationContext filterContext) {
        }
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext) {
            if (filterContext.Result is HttpUnauthorizedResult) {
                filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                {
                    { "controller", "Account" },
                    { "action", "AccessDenied" },
                    { "area", "Orchard.Users"},
                    { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                });
            }
    }
}
