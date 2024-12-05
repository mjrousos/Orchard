using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Reflection;

namespace Orchard.Projections.ModelBinding {
    /// <summary>
    /// Defines a service to provide properties processing for Model Binding.
    /// An implementation is responsible for returning a specific Form, and processing
    /// the output of a value based on how the form is configured.
    /// </summary>
    public interface IPropertyEditor : IDependency {
        /// <summary>
        /// Whether this instance can handle a given storage type
        /// </summary>
        bool CanHandle(Type type);
        /// The name of the form which will represent this editor
        string FormName { get; }
        /// Formats the value based on the Form state
        dynamic Format(dynamic display, object value, dynamic formState);
    }
}
