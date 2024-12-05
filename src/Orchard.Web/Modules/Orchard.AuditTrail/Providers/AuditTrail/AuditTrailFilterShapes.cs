using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;

namespace Orchard.AuditTrail.Providers.AuditTrail {
    public class AuditTrailFilterShapes : IDependency {
        [Shape]
        public void AuditTrailFilterDisplay(dynamic Shape, dynamic Display, TextWriter Output) {
            DispayChildren(Shape, Display, Output);
        }
        private void DispayChildren(dynamic shape, dynamic display, TextWriter output) {
            foreach (var child in shape) {
                output.Write(display(child));
            }
    }
}
