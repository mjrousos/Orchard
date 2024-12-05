using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Projections.Models;

namespace Orchard.Projections.Descriptors.Layout {
    public class LayoutContext {
        public dynamic State { get; set; }
        public LayoutRecord LayoutRecord { get; set; }
    }
}
