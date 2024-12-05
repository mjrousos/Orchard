using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Mvc.Routes;

namespace Orchard.WebApi.Routes {
    public interface IHttpRouteProvider : IDependency {
        void GetRoutes(ICollection<RouteDescriptor> routes);
    }
}
