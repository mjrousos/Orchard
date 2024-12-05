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
    public class Button : FormElement {
        public override string ToolboxIcon {
            get { return "\uf096"; }
        }
        public string Text {
            get { return this.Retrieve(x => x.Text, () => "Submit"); }
            set { this.Store(x => x.Text, value); }
    }
}
