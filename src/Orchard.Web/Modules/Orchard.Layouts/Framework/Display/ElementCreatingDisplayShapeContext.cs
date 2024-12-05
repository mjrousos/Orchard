using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Framework.Display {
    public class ElementCreatingDisplayShapeContext {
        public IContent Content { get; set; }
        public Element Element { get; set; }
        public string DisplayType { get; set; }
        public bool Cancel { get; set; }
    }
}
