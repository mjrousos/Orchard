using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AuditTrail.Services.Models;
using Orchard.Events;

namespace Orchard.AuditTrail.Services {
    public interface IAuditTrailEventHandler : IEventHandler {
        void Create(AuditTrailCreateContext context);
        void Filter(QueryFilterContext context);
        void DisplayFilter(DisplayFilterContext context);
    }
}
