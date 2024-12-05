using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Services {
    public class HtmlFilterContext {
        public string Flavor { get; set; }
        public IDictionary<string, object> Data { get; set; } = new Dictionary<string, object>();
    }
}
