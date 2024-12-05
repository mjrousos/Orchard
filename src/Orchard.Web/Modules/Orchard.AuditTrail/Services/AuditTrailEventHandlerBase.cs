using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AuditTrail.Services.Models;

namespace Orchard.AuditTrail.Services {
    public class AuditTrailEventHandlerBase : Component, IAuditTrailEventHandler {
        public virtual void Create(AuditTrailCreateContext context) {}
        public virtual void Filter(QueryFilterContext context) {}
        public virtual void DisplayFilter(DisplayFilterContext context) { }
    }
}
