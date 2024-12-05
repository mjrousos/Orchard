using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Specialized;

namespace Orchard.DynamicForms.Services {
    public class ReadElementValuesContext {
        public ReadElementValuesContext() {
            Output = new NameValueCollection();
        }
        public IValueProvider ValueProvider { get; set; }
        public NameValueCollection Output { get; set; }
    }
}
