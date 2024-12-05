using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Orchard.Setup {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptor = new RouteDescriptor {
                Route = new Route(
                        "{controller}/{action}",
                        new RouteValueDictionary {
                            {"area", "Orchard.Setup"},
                            {"controller", "Setup"},
                            {"action", "Index"}
                        },
                            {"area", "Orchard.Setup"}
                        new MvcRouteHandler())
            };
            routes.Add(routeDescriptor);
        }
    }
}
