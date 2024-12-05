using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Mvc.ModelBinders {
    public class ModelBinderDescriptor {
        public Type Type { get; set; }
        public IModelBinder ModelBinder { get; set; }
    }
}
