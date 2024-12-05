using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.AuditTrail.Models;

namespace Orchard.AuditTrail.Services.Models {
    public class QueryFilterContext {
        public QueryFilterContext(IQueryable<AuditTrailEventRecord> query, Filters filters) {
            Query = query;
            Filters = filters;
        }
        public IQueryable<AuditTrailEventRecord> Query { get; set; }
        public Filters Filters { get; set; }
    }
}
