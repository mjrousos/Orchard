using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Helpers;

namespace Orchard.DynamicForms.Elements {
    public abstract class FormElementWithPlaceholder : LabeledFormElement {
        public string Placeholder {
            get { return this.Retrieve(x => x.Placeholder); }
            set { this.Store(x => x.Placeholder, value); }
        }
    }
}
