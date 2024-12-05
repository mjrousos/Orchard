using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Alias.Implementation.Holder {
    public class AliasInfo {
        public string Area { get; set; }
        public string Path { get; set; }
        public IDictionary<string, string> RouteValues { get; set; }
        public bool IsManaged { get; set; }
    }
}
