using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;

namespace Orchard.Tests.ContentManagement.Models {
    public class StyledHandler : ContentHandler {
        public StyledHandler() {
            OnGetDisplayShape<StyledPart>((ctx, part) => ctx.Shape.Zones["Main"].Add(part, "10"));
        }
        protected override void Activating(ActivatingContentContext context) {
            if (context.ContentType == "alpha") {
                context.Builder.Weld<StyledPart>();
            }
    }
}
