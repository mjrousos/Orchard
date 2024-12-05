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
    public interface ISslSettingsProvider : IDependency {
        /// <summary>
        /// Gets whether authentication cookies should only be transmitted over SSL or not.
        /// </summary>
        bool GetRequiresSSL();
    }
}
