using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Tests.ContentManagement.Models;

namespace Orchard.Tests.ContentManagement.Handlers {
    public class AlphaPartHandler : ContentHandler {
        public AlphaPartHandler() {
            Filters.Add(new ActivatingFilter<AlphaPart>("alpha"));
            OnGetDisplayShape<AlphaPart>((ctx, part) => ctx.Shape.Zones["Main"].Add(part, "3"));
        }
    }
}
