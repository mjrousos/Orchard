using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AuditTrail.Models;
using Orchard.AuditTrail.Services;
using Orchard.AuditTrail.Services.Models;

namespace Orchard.AuditTrail.Providers.Content {
    public class ContentAuditTrailEventHandler : AuditTrailEventHandlerBase {
        public override void Create(AuditTrailCreateContext context) {
            var content = context.Properties.ContainsKey("Content") ? (IContent)context.Properties["Content"] : default(IContent);
            var auditTrailPart = content != null ? content.As<AuditTrailPart>() : default(AuditTrailPart);
            if (auditTrailPart == null)
                return;
            context.Comment = auditTrailPart.Comment;
        }
    }
}
