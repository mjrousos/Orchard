using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Mvc.ModelBinders {
    public class ModelBinderPublisher : IModelBinderPublisher {
        private readonly ModelBinderDictionary _binders;
        public ModelBinderPublisher(ModelBinderDictionary binders) {
            _binders = binders;
        }
        public void Publish(IEnumerable<ModelBinderDescriptor> binders) {
            // MultiTenancy: should hook default model binder instead and rely on shell-specific binders (instead adding to type dictionary)
            foreach (var descriptor in binders) {
                _binders[descriptor.Type] = descriptor.ModelBinder;
            }
    }
}
