using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;

namespace Orchard.Environment.Extensions.Models {
    public class FeatureDescriptor {
        public FeatureDescriptor() {
            Dependencies = Enumerable.Empty<string>();
            LifecycleStatus = LifecycleStatus.Production;
        }
        public ExtensionDescriptor Extension { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Priority { get; set; }
        public LifecycleStatus LifecycleStatus { get; set; }
        public IEnumerable<string> Dependencies { get; set; }
    }
}
