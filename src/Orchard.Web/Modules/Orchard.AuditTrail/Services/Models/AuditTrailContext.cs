using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.AuditTrail.Services.Models {
    public class AuditTrailContext {
        public AuditTrailContext() {
            EventData = new Dictionary<string, object>();
        }
        public string Event { get; set; }
        public IUser User { get; set; }
        public IDictionary<string, object> Properties { get; set; }
        public IDictionary<string, object> EventData { get; set; }
        public string EventFilterKey { get; set; }
        public string EventFilterData { get; set; }
        public AuditTrailEventDescriptor EventDescriptor { get; set; }
    }
}
