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

namespace Orchard.Projections.Descriptors.Layout {
    public class LayoutComponentResult {
        public ContentItem ContentItem { get; set; }
        public ContentItemMetadata ContentItemMetadata { get; set; }
        public dynamic Properties { get; set; }
    }
}
