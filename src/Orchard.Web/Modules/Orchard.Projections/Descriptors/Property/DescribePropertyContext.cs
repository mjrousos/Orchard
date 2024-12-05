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

namespace Orchard.Projections.Descriptors.Property {
    public class DescribePropertyContext {
        private readonly Dictionary<string, DescribePropertyFor> _describes = new Dictionary<string, DescribePropertyFor>();
        public IEnumerable<TypeDescriptor<PropertyDescriptor>> Describe() {
            return _describes.Select(kp => new TypeDescriptor<PropertyDescriptor> {
                Category = kp.Key,
                Name = kp.Value.Name,
                Description = kp.Value.Description,
                Descriptors = kp.Value.Types
            });
        }
        public DescribePropertyFor For(string category) {
            return For(category, null, null);
        public DescribePropertyFor For(string category, LocalizedString name, LocalizedString description) {
            DescribePropertyFor describeFor;
            if (!_describes.TryGetValue(category, out describeFor)) {
                describeFor = new DescribePropertyFor(category, name, description);
                _describes[category] = describeFor;
            }
            return describeFor;
    }
}
