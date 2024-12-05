using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;

namespace Orchard.Projections.Descriptors.Filter {
    public class DescribeFilterContext {
        private readonly Dictionary<string, DescribeFilterFor> _describes = new Dictionary<string, DescribeFilterFor>();
        public IEnumerable<TypeDescriptor<FilterDescriptor>> Describe() {
            return _describes.Select(kp => new TypeDescriptor<FilterDescriptor> {
                Category = kp.Key,
                Name = kp.Value.Name,
                Description = kp.Value.Description,
                Descriptors = kp.Value.Types
            });
        }
        public DescribeFilterFor For(string category) {
            return For(category, null, null);
        public DescribeFilterFor For(string category, LocalizedString name, LocalizedString description) {
            DescribeFilterFor describeFor;
            if (!_describes.TryGetValue(category, out describeFor)) {
                describeFor = new DescribeFilterFor(category, name, description);
                _describes[category] = describeFor;
            }
            return describeFor;
    }
}
