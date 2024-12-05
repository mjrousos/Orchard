using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Security {
    public interface ISecurityService : IDependency {
        /// <summary>
        /// Provides the TimeSpan telling how long an authentication cookie will be allowed to be valid.
        /// </summary>
        /// <returns>A <c>TimeSpan</c> with the value for the validity of an authentication cookie.</returns>
        TimeSpan GetAuthenticationCookieLifeSpan();
    }
}
