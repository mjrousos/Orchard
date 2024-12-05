using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.OpenId.Constants {
    public class General {
        public const string AuthenticationErrorUrl = "/Authentication/Error";
        public const string LogonCallbackUrl = "/Users/Account/LogonCallback";
        public const string OpenIdOwinMiddlewarePriority = "10";
        public const string LocalIssuer = "LOCAL AUTHORITY";
        public const string FormsIssuer = "Forms";
    }
}
