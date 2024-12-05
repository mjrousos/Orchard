using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Linq;
using Orchard.Environment.Extensions.Models;
using Orchard.Environment.Descriptor.Models;

namespace Orchard.Tests.Environment.Utility {
    static class Build {
        public static ShellDescriptor ShellDescriptor() {
            var descriptor = new ShellDescriptor {
                                                             Features = Enumerable.Empty<ShellFeature>(),
                                                             Parameters = Enumerable.Empty<ShellParameter>(),
                                                         };
            return descriptor;
        }
        public static ShellDescriptor WithFeatures(this ShellDescriptor descriptor, params string[] names) {
            descriptor.Features = descriptor.Features.Concat(
                names.Select(name => new ShellFeature { Name = name }));
        public static ShellDescriptor WithParameter<TComponent>(this ShellDescriptor descriptor, string name, string value) {
            descriptor.Parameters = descriptor.Parameters.Concat(
                new[] { new ShellParameter { Component = typeof(TComponent).FullName, Name = name, Value = value } });
        public static ExtensionDescriptor ExtensionDescriptor(string name, string displayName) {
            var descriptor = new ExtensionDescriptor {
                                                         Id = name,
                                                         Name = displayName,
                                                         Features = Enumerable.Empty<FeatureDescriptor>(),
                                                     };
        public static ExtensionDescriptor ExtensionDescriptor(string name) {
            return ExtensionDescriptor(name, name);
        public static ExtensionDescriptor WithFeatures(this ExtensionDescriptor descriptor, params string[] names) {
                names.Select(name => new FeatureDescriptor { Extension=descriptor , Id = name, }));
    }
}
