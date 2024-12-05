using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.DisplayManagement.Descriptors;
using Orchard.Environment.Extensions;

namespace Orchard.Core.Contents {
    [OrchardFeature("Contents.ControlWrapper")]
    public class ControlWrapper : IShapeTableProvider {
        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("Content").OnDisplaying(displaying => {
                if (!displaying.ShapeMetadata.DisplayType.Contains("Admin")) {
                    displaying.ShapeMetadata.Wrappers.Add("Content_ControlWrapper");
                }
            });
        }
    }
}
