using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Helpers;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Orchard.Environment.Extensions;
using Orchard.Owin;
using Owin;

namespace Orchard.OpenId.OwinMiddlewares {
    [OrchardFeature("Orchard.OpenId")]
    public class OpenId : IOwinMiddlewareProvider
    {
        public IEnumerable<OwinMiddlewareRegistration> GetOwinMiddlewares()
        {
            var cookieOptions = new CookieAuthenticationOptions();
            var authenticationType = CookieAuthenticationDefaults.AuthenticationType;
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            return new List<OwinMiddlewareRegistration> {
                new OwinMiddlewareRegistration {
                    Priority = "9",
                    Configure = app => {
                        app.SetDefaultSignInAsAuthenticationType(authenticationType);
                        app.UseCookieAuthentication(cookieOptions);
                    }
                }
            };
        }
    }
}
