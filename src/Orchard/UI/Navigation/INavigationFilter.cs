using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.UI.Navigation {
    /// <summary>
    /// Provides a way to alter the main navigation, for instance by dynamically injecting new items
    /// </summary>
    public interface INavigationFilter : IDependency {
        IEnumerable<MenuItem> Filter(IEnumerable<MenuItem> menuItems);
    }
}
