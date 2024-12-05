using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections;
using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Modules.Models {
    /// <summary>
    /// Represents a module's feature.
    /// </summary>
    public class ModuleFeature {
        /// <summary>
        /// The feature descriptor.
        /// </summary>
        public FeatureDescriptor Descriptor  { get; set; }
        /// Boolean value indicating if the feature is enabled.
        public bool IsEnabled { get; set; }
        /// Boolean value indicating if the feature needs a data update / migration.
        public bool NeedsUpdate { get; set; }
        /// Boolean value indicating if the module needs a version update.
        public bool NeedsVersionUpdate { get; set; }
        /// Boolean value indicating if the feature was recently installed.
        public bool IsRecentlyInstalled { get; set; }
        /// List of features that depend on this feature.
        public IEnumerable<FeatureDescriptor> DependentFeatures { get; set; }
    }
}
