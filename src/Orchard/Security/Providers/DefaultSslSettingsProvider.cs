using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Security;

namespace Orchard.Security.Providers {
    public class DefaultSslSettingsProvider : ISslSettingsProvider {
        public bool RequireSSL { get; set; }
        public DefaultSslSettingsProvider() {
            RequireSSL = FormsAuthentication.RequireSSL;
        }
        public bool GetRequiresSSL() {
            return RequireSSL;
    }
}
