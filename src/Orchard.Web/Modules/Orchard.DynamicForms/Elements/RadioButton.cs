using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Elements;
using Orchard.Layouts.Helpers;

namespace Orchard.DynamicForms.Elements {
    public class RadioButton : LabeledFormElement {
        public override string ToolboxIcon {
            get { return "\uf192"; }
        }
        public bool DefaultValue {
            get { return this.Retrieve(x => x.DefaultValue); }
            set { this.Store(x => x.DefaultValue, value); }
    }
}
