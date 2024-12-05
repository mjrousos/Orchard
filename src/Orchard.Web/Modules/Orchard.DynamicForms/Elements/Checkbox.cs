using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DynamicForms.Validators.Settings;

namespace Orchard.DynamicForms.Elements {
    public class CheckBox : LabeledFormElement {
        public override string ToolboxIcon {
            get { return "\uf046"; }
        }
        public CheckBoxValidationSettings ValidationSettings {
            get { return Data.GetModel<CheckBoxValidationSettings>(""); }
    }
}
