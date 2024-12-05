using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Modules.Models {
    /// <summary>
    /// Represents a module.
    /// </summary>
    public class ModuleEntry {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ModuleEntry() {
            Notifications = new List<string>();
        }
        /// The module's extension descriptor.
        public ExtensionDescriptor Descriptor { get; set; }
        /// Boolean value indicating if the module needs a version update.
        public bool NeedsVersionUpdate { get; set; }
        /// Boolean value indicating if the feature was recently installed.
        public bool IsRecentlyInstalled { get; set; }
        /// List of module notifications.
        public List<string> Notifications { get; set; }
        /// Indicates whether the module can be uninstalled by the user.
        public bool CanUninstall { get; set; }
    }
}
