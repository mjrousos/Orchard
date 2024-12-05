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
    public class Label : Element {
        public override string Category {
            get { return "Forms"; }
        }
        public override bool HasEditor {
            get { return true; }
        public string Text {
            get { return this.Retrieve<string>("LabelText"); }
            set { this.Store("LabelText", value); }
        public string For {
            get { return this.Retrieve<string>("LabelFor"); }
            set { this.Store("LabelFor", value); }
    }
}
