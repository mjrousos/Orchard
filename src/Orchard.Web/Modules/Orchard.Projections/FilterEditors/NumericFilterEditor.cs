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
    public class NumericFilterEditor : IFilterEditor {
        public NumericFilterEditor() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public bool CanHandle(Type type) {
            return new[] {
                typeof(Byte), 
                typeof(SByte), 
                typeof(Int16), 
                typeof(Int32), 
                typeof(Int64), 
                typeof(UInt16), 
                typeof(UInt32), 
                typeof(UInt64), 
                typeof(float), 
                typeof(double), 
                typeof(decimal), 
            }.Contains(type);
        public string FormName {
            get { return NumericFilterForm.FormName; }
        public Action<IHqlExpressionFactory> Filter(string property, dynamic formState) {
            return NumericFilterForm.GetFilterPredicate(formState, property);
        public LocalizedString Display(string property, dynamic formState) {
            return NumericFilterForm.DisplayFilter(property, formState, T);
    }
}
