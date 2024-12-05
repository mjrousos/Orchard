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
    public class ContentFieldBindingDescriptor {
        public ContentFieldBindingDescriptor() {
            BindingContexts = new List<BindingContext>();
        }
        public ContentPartFieldDefinition Field { get; set; }
        public IList<BindingContext> BindingContexts { get; set; }
    }
}
