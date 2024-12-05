using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DynamicForms.Validators.Settings;
using Orchard.Layouts.Helpers;

namespace Orchard.DynamicForms.Elements {
    public class TextArea : FormElementWithPlaceholder {
        public int? Rows {
            get { return this.Retrieve(x => x.Rows); }
            set { this.Store(x => x.Rows, value); }
        }
        public int? Columns {
            get { return this.Retrieve(x => x.Columns); }
            set { this.Store(x => x.Columns, value); }
        public TextAreaValidationSettings ValidationSettings {
            get { return Data.GetModel<TextAreaValidationSettings>(""); }
    }
}
