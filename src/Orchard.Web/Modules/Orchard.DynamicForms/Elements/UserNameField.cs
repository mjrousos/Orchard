using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.DynamicForms.Elements {
    public class UserNameField : FormElement {
        public override bool HasEditor {
            get { return false; }
        }

        public override string Name {
            get { return "UserName"; }
    }
}
