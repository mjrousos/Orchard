using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Orchard.Environment.Extensions.Loaders;
using Orchard.Environment.Extensions.Models;
using Orchard.FileSystems.Dependencies;

namespace Orchard.Environment.Extensions {
    public class ExtensionLoadingContext {
        public ExtensionLoadingContext() {
            ProcessedExtensions = new Dictionary<string, ExtensionProbeEntry>(StringComparer.OrdinalIgnoreCase);
            ProcessedReferences = new Dictionary<string, ExtensionReferenceProbeEntry>(StringComparer.OrdinalIgnoreCase);
            DeleteActions = new List<Action>();
            CopyActions = new List<Action>();
            NewDependencies = new List<DependencyDescriptor>();
        }
        public IDictionary<string, ExtensionProbeEntry> ProcessedExtensions { get; private set; }
        public IDictionary<string, ExtensionReferenceProbeEntry> ProcessedReferences { get; private set; }
        public IList<DependencyDescriptor> NewDependencies { get; private set; }
        public IList<Action> DeleteActions { get; private set; }
        public IList<Action> CopyActions { get; private set; }
        public bool RestartAppDomain { get; set; }
        /// <summary>
        /// Keep track of modification date of files (VirtualPath => DateTime)
        /// </summary>
        public ConcurrentDictionary<string, DateTime> VirtualPathModficationDates { get; set; }
        /// List of extensions (modules) present in the system
        public List<ExtensionDescriptor> AvailableExtensions { get; set; }
        /// List of extensions (modules) that were loaded during a previous successful run
        public List<DependencyDescriptor> PreviousDependencies { get; set; }
        /// The list of extensions/modules that are were present in the previous successful run
        /// and that are not present in the system anymore.
        public List<DependencyDescriptor> DeletedDependencies { get; set; }
        /// For every extension name, the list of loaders that can potentially load
        /// that extension (in order of "best-of" applicable)
        public IDictionary<string, IEnumerable<ExtensionProbeEntry>> AvailableExtensionsProbes { get; set; }
        /// For every reference name, list of potential loaders/locations
        public IDictionary<string, IEnumerable<ExtensionReferenceProbeEntry>> ReferencesByModule { get; set; }
        /// For every extension name, list of potential loaders/locations
        public IDictionary<string, IEnumerable<ExtensionReferenceProbeEntry>> ReferencesByName { get; set; }
    }
}
