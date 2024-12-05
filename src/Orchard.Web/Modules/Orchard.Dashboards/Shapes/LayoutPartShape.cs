using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DisplayManagement.Descriptors;

namespace Orchard.Dashboards.Shapes {
    public class LayoutPartShape : IShapeTableProvider {
        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("Parts_Layout").OnDisplaying(context => {
                if (context.ShapeMetadata.DisplayType != "Dashboard")
                    return;
                context.ShapeMetadata.Alternates.Add("Parts_Layout_Dashboard");
            });
        }
    }
}
