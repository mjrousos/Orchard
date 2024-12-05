using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Framework.Harvesters {
    public interface IElementHarvester : ISingletonDependency {
        IEnumerable<ElementDescriptor> HarvestElements(HarvestElementsContext context);
    }
}
