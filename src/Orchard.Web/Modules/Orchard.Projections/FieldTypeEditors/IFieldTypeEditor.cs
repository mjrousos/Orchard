using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Projections.Models;

namespace Orchard.Projections.FieldTypeEditors {
    /// <summary>
    /// Defines a service to provide information on how a specific data type
    /// is stored in the content fields index.
    /// </summary>
    public interface IFieldTypeEditor : IDependency {
        /// <summary>
        /// Whether this instance can handle a given storage type
        /// </summary>
        bool CanHandle(Type storageType);
        /// The name of the form which will represent this editor
        string FormName { get; }
        /// Generates a predicate based on the values which were provided
        /// by the user to the editor form
        Action<IHqlExpressionFactory> GetFilterPredicate(dynamic formState);
        /// Generates the textual representation of the filter
        LocalizedString DisplayFilter(string fieldName, string storageName, dynamic formState);
        /// Defines the relationship to the corresponding field indexing table for this editor
        Action<IAliasFactory> GetFilterRelationship(string aliasName);
    }
    public static class FieldTypeEditorExtensions {
        public static QueryVersionScopeOptions GetQueryVersionScope(this IFieldTypeEditor editor, string value) {
            if (!Enum.TryParse(value, out QueryVersionScopeOptions versionScope))
                versionScope = QueryVersionScopeOptions.Published;
            return versionScope;
        }
}
