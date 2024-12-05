using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Rules.Models {
    public class EventContext {
        public EventContext() {
            Tokens = new Dictionary<string, object>();
            Properties = new Dictionary<string, string>();
        }
        public IDictionary<string, object> Tokens { get; set; }
        public IDictionary<string, string> Properties { get; set; }
    }
}
