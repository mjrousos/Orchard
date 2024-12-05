using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.AuditTrail.Services.Models {
    public class AuditTrailCreateContext : AuditTrailContext {
        public string Comment { get; set; }
    }
}
