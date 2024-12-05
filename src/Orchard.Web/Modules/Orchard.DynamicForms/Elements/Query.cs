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
    public class Query : LabeledFormElement {
        public string InputType {
            get { return this.Retrieve(x => x.InputType, () => "SelectList"); }
            set { this.Store(x => x.InputType, value); }
        }
        public int? QueryId {
            get { return this.Retrieve(x => x.QueryId); }
            set { this.Store(x => x.QueryId, value); }
        public string OptionLabel {
            get { return this.Retrieve(x => x.OptionLabel); }
            set { this.Store(x => x.OptionLabel, value); }
        public string TextExpression {
            get { return this.Retrieve(x => x.TextExpression, () => "{Content.Title}"); }
        public string ValueExpression {
            get { return this.Retrieve(x => x.ValueExpression, () => "{Content.Id}"); }
        public string DefaultValue {
            get { return this.Retrieve(x => x.DefaultValue); }
        public EnumerationValidationSettings ValidationSettings {
            get { return Data.GetModel<EnumerationValidationSettings>(""); }
    }
}
