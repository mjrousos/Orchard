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
using Orchard.Environment.Extensions;

namespace Orchard.AuditTrail.Providers.AuditTrail {
    [OrchardFeature("Orchard.AuditTrail.Trimming")]
    public class AuditTrailTrimmingSettingsEventProvider : AuditTrailEventProviderBase {
        public const string TrimmingSettingsChanged = "TrimmingSettingsChanged";
        public override void Describe(DescribeContext context) {
            context.For("AuditTrailSettings", T("Audit Trail Settings"))
                .Event(this, TrimmingSettingsChanged, T("Trimming settings changed"), T("The audit trail trimming settings were changed."), enableByDefault: true);
        }
    }
}
