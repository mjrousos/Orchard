using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;

namespace Orchard.OutputCache.Services {
    /// <summary>
    /// Represents the logic deciding if the result of an action can be cached
    /// </summary>
    public interface ICacheControlStrategy : IDependency {
        bool IsCacheable(ActionResult result, HttpResponseBase response);
    }
}
