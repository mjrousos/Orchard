using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Layouts.Framework.Elements {
    public class LayoutSavingContext {
        public IUpdateModel Updater { get; set; }
        public IEnumerable<Element> Elements { get; set; }
        public IEnumerable<Element> RemovedElements { get; set; }
        public IContent Content { get; set; }
    }
}
