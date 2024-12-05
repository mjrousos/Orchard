using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.AuditTrail.Providers.AuditTrail {
    public class AuditTrailEventSettingEventData
    {
        public string EventName { get; set; }
        public string EventDisplayName { get; set; }
        public string EventCategory { get; set; }
        public bool IsEnabled { get; set; }
    }
}
