using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Themes.Models {
    /// <summary>
    /// Represents a theme.
    /// </summary>
    public class ThemeEntry {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ThemeEntry() {
            Notifications = new List<string>();
        }
        /// Instantiates a theme based on an extension descriptor.
        /// <param name="extensionDescriptor">The extension descriptor.</param>
        public ThemeEntry(ExtensionDescriptor extensionDescriptor) {
            Descriptor = extensionDescriptor;
        /// The theme's extension descriptor.
        public ExtensionDescriptor Descriptor { get; set; }
        /// Boolean value indicating wether the theme is enabled.
        public bool Enabled { get; set; }
        /// Boolean value indicating wether the theme needs a data update / migration.
        public bool NeedsUpdate { get; set; }
        /// Boolean value indicating if the module needs a version update.
        public bool NeedsVersionUpdate { get; set; }
        /// Boolean value indicating if the feature was recently installed.
        public bool IsRecentlyInstalled { get; set; }
        /// Boolean value indicating if the theme can be uninstalled.
        public bool CanUninstall { get; set; }
        /// List of theme notifications.
        public List<string> Notifications { get; set; }
        /// The theme's name.
        public string Name { get { return Descriptor.Name; } }
    }
}
