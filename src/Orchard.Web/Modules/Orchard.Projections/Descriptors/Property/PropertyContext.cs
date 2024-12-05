using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Projections.Descriptors.Property {
    public class PropertyContext {
        public PropertyContext() {
            Tokens = new Dictionary<string, object>();
        }
        public IDictionary<string, object> Tokens { get; set; }
        public dynamic State { get; set; }
    }
}
