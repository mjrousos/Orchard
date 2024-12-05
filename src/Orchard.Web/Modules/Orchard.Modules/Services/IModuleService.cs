using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Modules.Models;

namespace Orchard.Modules.Services {
    public interface IModuleService : IDependency {
        /// <summary>
        /// Retrieves an enumeration of the available features together with its state (enabled / disabled).
        /// </summary>
        /// <returns>An enumeration of the available features together with its state (enabled / disabled).</returns>
        IEnumerable<ModuleFeature> GetAvailableFeatures();
        /// Enables a list of features.
        /// <param name="featureIds">The IDs for the features to be enabled.</param>
        void EnableFeatures(IEnumerable<string> featureIds);
        /// <param name="force">Boolean parameter indicating if the feature should enable it's dependencies if required or fail otherwise.</param>
        void EnableFeatures(IEnumerable<string> featureIds, bool force);
        /// Disables a list of features.
        /// <param name="featureIds">The IDs for the features to be disabled.</param>
        void DisableFeatures(IEnumerable<string> featureIds);
        /// <param name="force">Boolean parameter indicating if the feature should disable the features which depend on it if required or fail otherwise.</param>
        void DisableFeatures(IEnumerable<string> featureIds, bool force);
        /// Determines if an extension was recently installed.
        /// <param name="extensionDescriptor">The extension descriptor.</param>
        /// <returns>True if the feature was recently installed; false otherwise.</returns>
        bool IsRecentlyInstalled(ExtensionDescriptor extensionDescriptor);
        /// Gets a list of dependent features of a given feature.
        /// <param name="featureId">ID of a feature.</param>
        /// <returns>List of dependent feature descriptors.</returns>
        IEnumerable<FeatureDescriptor> GetDependentFeatures(string featureId);
    }
}
