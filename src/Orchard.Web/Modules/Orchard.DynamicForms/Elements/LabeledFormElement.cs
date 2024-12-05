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
    public abstract class LabeledFormElement : FormElement {
        public string Label {
            get { return this.Retrieve(x => x.Label); }
            set { this.Store(x => x.Label, value); }
        }
        public bool ShowLabel {
            get { return this.Retrieve(x => x.ShowLabel); }
            set { this.Store(x => x.ShowLabel, value); }
    }
}
