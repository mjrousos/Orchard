using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;

namespace Orchard.Environment.Extensions.Models {
    public class Feature {
        public FeatureDescriptor Descriptor { get; set; }
        public IEnumerable<Type> ExportedTypes { get; set; }
    }
}
