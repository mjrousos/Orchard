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
using Orchard.Projections.ModelBinding;
using Orchard.Projections.PropertyEditors.Forms;

namespace Orchard.Projections.PropertyEditors {
    public class DateTimePropertyEditor : IPropertyEditor {
        private readonly IWorkContextAccessor _workContextAccessor;
        public DateTimePropertyEditor(
            IWorkContextAccessor workContextAccessor) {
            _workContextAccessor = workContextAccessor;
        }
        public bool CanHandle(Type type) {
            return new[] { typeof(DateTime), typeof(DateTime?) }.Contains(type);
        public string FormName {
            get { return DateTimePropertyForm.FormName; }
        public dynamic Format(dynamic display, object value, dynamic formState) {
            var culture = _workContextAccessor.GetContext().CurrentCulture;
            return DateTimePropertyForm.FormatDateTime(display, Convert.ToDateTime(value, new System.Globalization.CultureInfo(culture)), formState, culture);
    }
}
