using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DisplayManagement.Descriptors;

namespace Orchard.Projections {
    public class Shapes : IShapeTableProvider {
        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("Parts_ProjectionPart")
                .OnDisplaying(displaying => {
                    var shape = displaying.Shape;
                    if (!string.IsNullOrWhiteSpace(shape.ContentPart.Record.PagerSuffix)) {
                        shape.Metadata.Alternates.Add("Parts_ProjectionPart__" + shape.ContentPart.Record.PagerSuffix);
                    }
                });
        }
    }
}
