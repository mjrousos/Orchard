using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Environment.Extensions.Models {
    public class ExtensionDescriptor {
        public ExtensionDescriptor() {
            LifecycleStatus = LifecycleStatus.Production;
        }
        /// <summary>
        /// Virtual path base, "~/Themes", "~/Modules", or "~/Core"
        /// </summary>
        public string Location { get; set; }
        /// Folder name under virtual path base
        public string Id { get; set; }
        public string VirtualPath { get { return Location + "/" + Id; } }
        /// The extension type.
        public string ExtensionType { get; set; }
        
        // extension metadata
        public string Name { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string OrchardVersion { get; set; }
        public string Author { get; set; }
        public string WebSite { get; set; }
        public string Tags { get; set; }
        public string AntiForgery { get; set; }
        public string Zones { get; set; }
        public string BaseTheme { get; set; }
        public string SessionState { get; set; }
        public LifecycleStatus LifecycleStatus { get; set; }
        public IEnumerable<FeatureDescriptor> Features { get; set; }
    }
}
