using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.AuditTrail.Helpers {
    public static class ControllerExtensions {
        public static RedirectResult RedirectReturn(this Controller controller, string returnUrl = null, Func<string> defaultReturnUrl = null) {
            return new RedirectResult(controller.Request.GetReturnUrl(returnUrl, defaultReturnUrl));
        }
    }
}
