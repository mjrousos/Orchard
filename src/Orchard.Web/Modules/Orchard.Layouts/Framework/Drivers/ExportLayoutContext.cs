using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Models;

namespace Orchard.Layouts.Framework.Drivers {
    public class ExportLayoutContext {
        public ILayoutAspect Layout { get; set; }
    }
}
