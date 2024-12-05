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
using Orchard.Projections.Models;

namespace Orchard.Projections.FieldTypeEditors {
    /// <summary>
    /// <see cref="IFieldTypeEditor"/> implementation for DateTime properties
    /// </summary>
    public class DateTimeFieldTypeEditor : IFieldTypeEditor {
        private readonly IClock _clock;
        
        public Localizer T { get; set; }
        public DateTimeFieldTypeEditor(IClock clock) {
            _clock = clock;
            T = NullLocalizer.Instance;
        }
        public bool CanHandle(Type storageType) {
            return new[] { typeof(DateTime), typeof(DateTime?) }.Contains(storageType);
        public string FormName {
            get { return DateTimeFilterForm.FormName; }
        public Action<IHqlExpressionFactory> GetFilterPredicate(dynamic formState) {
            return DateTimeFilterForm.GetFilterPredicate(
                formState,
                this.GetQueryVersionScope((string)formState.VersionScope).ToVersionedFieldIndexColumnName(),
                _clock.UtcNow,
                true);
        public LocalizedString DisplayFilter(string fieldName, string storageName, dynamic formState) {
            return DateTimeFilterForm.DisplayFilter(fieldName + " " + storageName, formState, T);
        public Action<IAliasFactory> GetFilterRelationship(string aliasName) {
            return x => x.ContentPartRecord<FieldIndexPartRecord>().Property("IntegerFieldIndexRecords", aliasName);
    }
}
