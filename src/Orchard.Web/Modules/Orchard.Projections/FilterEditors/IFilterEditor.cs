using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Projections.FilterEditors {
    /// <summary>
    /// Defines a service to provide filters.
    /// An implementation is responsible for returning a specific Form, and return a predicate.
    /// </summary>
    public interface IFilterEditor : IDependency {
        /// <summary>
        /// Whether this instance can handle a given storage type
        /// </summary>
        bool CanHandle(Type type);
        /// The name of the form which will represent this editor
        string FormName { get; }
        /// Returns a predicate representing the filter
        Action<IHqlExpressionFactory> Filter(string property, dynamic formState);
        /// Returns a textual description of a filter
        LocalizedString Display(string property, dynamic formState);
    }
}
