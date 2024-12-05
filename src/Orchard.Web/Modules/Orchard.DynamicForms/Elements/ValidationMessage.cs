using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Helpers;

namespace Orchard.DynamicForms.Elements {
    public class ValidationMessage : Element {
        public override string Category {
            get { return "Forms"; }
        }
        public string For {
            get { return this.Retrieve(x => x.For); }
            set { this.Store(x => x.For, value); }
    }
}
