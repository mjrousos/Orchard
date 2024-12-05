using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Orchard.Projections.FilterEditors.Forms;

namespace Orchard.Projections.FilterEditors {
    public class BooleanFilterEditor : IFilterEditor {
        public BooleanFilterEditor() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public bool CanHandle(Type type) {
            return new[] {
                typeof(Boolean),
                typeof(Boolean?)
            }.Contains(type);
        public string FormName {
            get { return BooleanFilterForm.FormName; }
        public Action<IHqlExpressionFactory> Filter(string property, dynamic formState) {
            return BooleanFilterForm.GetFilterPredicate(formState, property);
        public LocalizedString Display(string property, dynamic formState) {
            return BooleanFilterForm.DisplayFilter(property, formState, T);
    }
}
