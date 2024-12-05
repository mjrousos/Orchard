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
    /// <see cref="IFieldTypeEditor"/> implementation for string properties
    /// </summary>
    public class StringFieldTypeEditor : IFieldTypeEditor {
        public Localizer T { get; set; }
        public StringFieldTypeEditor() {
            T = NullLocalizer.Instance;
        }
        public bool CanHandle(Type storageType) {
            return new[] { typeof(string), typeof(char) }.Contains(storageType);
        public string FormName {
            get { return StringFilterForm.FormName; }
        public Action<IHqlExpressionFactory> GetFilterPredicate(dynamic formState) {
            return StringFilterForm.GetFilterPredicate(
                formState,
                this.GetQueryVersionScope((string)formState.VersionScope).ToVersionedFieldIndexColumnName());
        public LocalizedString DisplayFilter(string fieldName, string storageName, dynamic formState) {
            return StringFilterForm.DisplayFilter(fieldName + " " + storageName, formState, T);
        public Action<IAliasFactory> GetFilterRelationship(string aliasName) {
            return x => x.ContentPartRecord<FieldIndexPartRecord>().Property("StringFieldIndexRecords", aliasName);
    }
}
