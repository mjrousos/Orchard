using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AuditTrail.Helpers;
using Orchard.AuditTrail.Services;
using Orchard.AuditTrail.Services.Models;
using Orchard.DisplayManagement.Descriptors;
using Orchard.DisplayManagement.Implementation;

namespace Orchard.AuditTrail.Shapes {
    public abstract class AuditTrailEventShapeAlteration<T> : IShapeTableProvider where T : IAuditTrailEventProvider {
        protected abstract string EventName { get; }
        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("AuditTrailEvent").OnDisplaying(context => {
                var descriptor = (AuditTrailEventDescriptor) context.Shape.Descriptor;
                if (descriptor.Event != EventNameExtensions.GetFullyQualifiedEventName<T>(EventName))
                    return;
                OnAlterShape(context);
            });
        }
        protected virtual void OnAlterShape(ShapeDisplayingContext context) {}
    }
}
