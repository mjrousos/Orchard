using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AuditTrail.Services;
using Orchard.AuditTrail.Services.Models;

namespace Orchard.AuditTrail.Providers.AuditTrail {
    public class AuditTrailSettingsEventProvider : AuditTrailEventProviderBase {
        
        public const string EventsChanged = "EventsChanged";
        public override void Describe(DescribeContext context) {
            context.For("AuditTrailSettings", T("Audit Trail Settings"))
                .Event(this, EventsChanged, T("Events changed"), T("The audit trail event settings were changed."), enableByDefault: true, isMandatory: true);
        }
    }
}
