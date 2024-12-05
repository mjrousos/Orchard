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
    public class DateTimeFilterEditor : IFilterEditor {
        private readonly IClock _clock;
        public DateTimeFilterEditor(IClock clock) {
            _clock = clock;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public bool CanHandle(Type type) {
            return new[] {
                typeof(DateTime),
                typeof(DateTime?),
            }.Contains(type);
        public string FormName {
            get { return DateTimeFilterForm.FormName; }
        public Action<IHqlExpressionFactory> Filter(string property, dynamic formState) {
            return DateTimeFilterForm.GetFilterPredicate(formState, property, _clock.UtcNow);
        public LocalizedString Display(string property, dynamic formState) {
            return DateTimeFilterForm.DisplayFilter(property, formState, T);
    }
}
