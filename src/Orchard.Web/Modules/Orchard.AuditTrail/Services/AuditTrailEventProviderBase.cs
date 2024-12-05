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
    public abstract class AuditTrailEventProviderBase : Component, IAuditTrailEventProvider {
        public abstract void Describe(DescribeContext context);
    }
}
