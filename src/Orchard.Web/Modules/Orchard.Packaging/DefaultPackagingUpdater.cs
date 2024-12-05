using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment;
using Orchard.Environment.Extensions;
using Orchard.Environment.Extensions.Models;
using Orchard.Packaging.Services;

namespace Orchard.Packaging {
    [OrchardFeature("Gallery")]
    public class DefaultPackagingUpdater : IFeatureEventHandler {
        private readonly IPackagingSourceManager _packagingSourceManager;
        public DefaultPackagingUpdater(IPackagingSourceManager packagingSourceManager) {
            _packagingSourceManager = packagingSourceManager;
        }
        public Localizer T { get; set; }
        public void Installing(Feature feature) {
        public void Installed(Feature feature) {
            if (feature.Descriptor.Id == "Gallery") {
                _packagingSourceManager.AddSource("Orchard Gallery", "https://gallery.orchardproject.net/api/FeedService");
            }
        public void Enabling(Feature feature) {
        public void Enabled(Feature feature) {
        public void Disabling(Feature feature) {
        public void Disabled(Feature feature) {
        public void Uninstalling(Feature feature) {
        public void Uninstalled(Feature feature) {
    }
}
