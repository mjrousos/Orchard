using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.DynamicForms.Services.Models {
    public class BindingDescribeContext {
        private readonly IDictionary<string, BindingContext> _describes = new Dictionary<string, BindingContext>();
        public IEnumerable<BindingContext> Describe() {
            return _describes.Values;
        }
        public BindingContext<T> For<T>() {
            BindingContext bindingContext;
            var key = typeof (T).Name;
            if (!_describes.TryGetValue(key, out bindingContext)) {
                bindingContext = new BindingContext<T>();
                _describes[key] = bindingContext;
            }
            return (BindingContext<T>)bindingContext;
    }
}
