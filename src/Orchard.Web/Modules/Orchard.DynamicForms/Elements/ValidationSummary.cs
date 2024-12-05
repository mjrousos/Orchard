using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Framework.Elements;

namespace Orchard.DynamicForms.Elements {
    public class ValidationSummary : Element {
        public override string Category {
            get { return "Forms"; }
        }
        public override bool HasEditor {
            get { return false; }
    }
}
