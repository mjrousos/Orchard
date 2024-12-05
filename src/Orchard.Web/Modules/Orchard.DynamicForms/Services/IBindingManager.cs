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
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Services {
    public interface IBindingManager : IDependency {
        IEnumerable<BindingContext> DescribeBindingContexts();
        IEnumerable<ContentPartBindingDescriptor> DescribeBindingsFor(ContentTypeDefinition contentTypeDefinition);
    }
}
