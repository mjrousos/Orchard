using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.MediaProcessing.Descriptors;
using Orchard.MediaProcessing.Descriptors.Filter;

namespace Orchard.MediaProcessing.Services {
    public class ImageProcessingManager : IImageProcessingManager {
        private readonly IEnumerable<IImageFilterProvider> _filterProviders;
        public ImageProcessingManager(
            IEnumerable<IImageFilterProvider> filterProviders) {
            _filterProviders = filterProviders;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public IEnumerable<TypeDescriptor<FilterDescriptor>> DescribeFilters() {
            var context = new DescribeFilterContext();
            foreach (var provider in _filterProviders) {
                provider.Describe(context);
            }
            return context.Describe();
    }
}
