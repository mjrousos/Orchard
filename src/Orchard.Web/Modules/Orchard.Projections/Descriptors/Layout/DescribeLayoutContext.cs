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

namespace Orchard.Projections.Descriptors.Layout {
    public class DescribeLayoutContext {
        private readonly Dictionary<string, DescribeLayoutFor> _describes = new Dictionary<string, DescribeLayoutFor>();
        public IEnumerable<TypeDescriptor<LayoutDescriptor>> Describe() {
            return _describes.Select(kp => new TypeDescriptor<LayoutDescriptor> {
                Category = kp.Key,
                Name = kp.Value.Name,
                Description = kp.Value.Description,
                Descriptors = kp.Value.Types
            });
        }
        public DescribeLayoutFor For(string category) {
            return For(category, null, null);
        public DescribeLayoutFor For(string category, LocalizedString name, LocalizedString description) {
            DescribeLayoutFor describeFor;
            if (!_describes.TryGetValue(category, out describeFor)) {
                describeFor = new DescribeLayoutFor(category, name, description);
                _describes[category] = describeFor;
            }
            return describeFor;
    }
}
