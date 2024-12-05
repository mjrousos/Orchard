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

namespace Orchard.Projections.Descriptors.Layout {
    public class LayoutDescriptor {
        public string Category { get; set; }
        public string Type { get; set; }
        public LocalizedString Name { get; set; }
        public LocalizedString Description { get; set; }
        public Func<LayoutContext, IEnumerable<LayoutComponentResult>, dynamic> Render { get; set; }
        public Func<LayoutContext, LocalizedString> Display { get; set; }
        public string Form { get; set; }
    }
}
