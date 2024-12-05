using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.DynamicForms.Services.Models {
    public class ContentPartBindingDescriptor {
        public ContentPartBindingDescriptor() {
            BindingContexts = new List<BindingContext>();
            FieldBindings = new List<ContentFieldBindingDescriptor>();
        }
        public ContentTypePartDefinition Part { get; set; }
        public IList<BindingContext> BindingContexts { get; set; }
        public IList<ContentFieldBindingDescriptor> FieldBindings { get; set; }
    }
}
