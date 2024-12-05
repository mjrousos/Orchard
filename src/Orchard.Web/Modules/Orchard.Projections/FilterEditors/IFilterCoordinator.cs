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
    /// Coordinated all available <see cref="IFilterEditor"/> to apply specific formatting on a model binding property
    /// </summary>
    public interface IFilterCoordinator : IDependency {
        
        /// <summary>
        /// Returns the form for a specific type
        /// </summary>
        string GetForm(Type type);
        /// Returns a predicate representing the filter for a specific type
        Action<IHqlExpressionFactory> Filter(Type type, string property, dynamic formState);
        /// Returns a textual description of a filter
        LocalizedString Display(Type type, string property, dynamic formState);
    }
}
