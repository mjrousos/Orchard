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
using Orchard.Environment.Extensions;

namespace Orchard.Environment.Features {
    public delegate void FeatureDependencyNotificationHandler(string messageFormat, string featureId, IEnumerable<string> featureIds);
    public interface IFeatureManager : IDependency {
        FeatureDependencyNotificationHandler FeatureDependencyNotification { get; set; }
        /// <summary>
        /// Retrieves the available features.
        /// </summary>
        /// <returns>An enumeration of feature descriptors for the available features.</returns>
        IEnumerable<FeatureDescriptor> GetAvailableFeatures();
        /// Retrieves the enabled features.
        /// <returns>An enumeration of feature descriptors for the enabled features.</returns>
        IEnumerable<FeatureDescriptor> GetEnabledFeatures();
        /// Retrieves the disabled features.
        /// <returns>An enumeration of feature descriptors for the disabled features.</returns>
        IEnumerable<FeatureDescriptor> GetDisabledFeatures();
        /// Enables a list of features.
        /// <param name="featureIds">The IDs for the features to be enabled.</param>
        /// <returns>An enumeration with the enabled feature IDs.</returns>
        IEnumerable<string> EnableFeatures(IEnumerable<string> featureIds);
        /// <param name="force">Boolean parameter indicating if the feature should enable it's dependencies if required or fail otherwise.</param>
        IEnumerable<string> EnableFeatures(IEnumerable<string> featureIds, bool force);
        /// Disables a list of features.
        /// <param name="featureIds">The IDs for the features to be disabled.</param>
        /// <returns>An enumeration with the disabled feature IDs.</returns>
        IEnumerable<string> DisableFeatures(IEnumerable<string> featureIds);
        /// <param name="force">Boolean parameter indicating if the feature should disable the features which depend on it if required or fail otherwise.</param>
        IEnumerable<string> DisableFeatures(IEnumerable<string> featureIds, bool force);
        /// Lists all enabled features that depend on a given feature.
        /// <param name="featureId">ID of the feature to check.</param>
        /// <returns>An enumeration with dependent feature IDs.</returns>
        IEnumerable<string> GetDependentFeatures(string featureId);
        /// Checks whether the feature's extension has a loadee, i.e. a suitable <see cref="IExtensionLoader"/> can be found.
        /// <returns><c>True</c> if a suitable <see cref="IExtensionLoader"/> can be found.</returns>
        bool HasLoader(string featureId);
    }
}
