using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using Orchard.Environment.Extensions;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Tests.Stubs {
    public class StubExtensionManager : IExtensionManager {
        public ExtensionDescriptor GetExtension(string name) {
            throw new NotImplementedException();
        }
        public IEnumerable<ExtensionDescriptor> AvailableExtensions() {
            throw new NotSupportedException();
        public IEnumerable<FeatureDescriptor> AvailableFeatures() {
        public IEnumerable<Feature> LoadFeatures(IEnumerable<FeatureDescriptor> featureDescriptors) {
    }
}
