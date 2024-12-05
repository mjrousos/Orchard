using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.DisplayManagement {
    /// <summary>
    /// Used to create a dynamic, contextualized Display object to dispatch shape rendering
    /// </summary>
    public interface IDisplayHelperFactory : IDependency {
        dynamic CreateHelper(ViewContext viewContext, IViewDataContainer viewDataContainer);
    }
}
