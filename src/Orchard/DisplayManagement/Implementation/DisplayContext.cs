using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.DisplayManagement.Implementation {
    public class DisplayContext  {
        public DisplayHelper Display { get; set; }
        public ViewContext ViewContext { get; set; }
        public IViewDataContainer ViewDataContainer { get; set; }
        public object Value { get; set; }
    }
}
