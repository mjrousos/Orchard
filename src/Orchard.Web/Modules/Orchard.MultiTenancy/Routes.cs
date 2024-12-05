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

namespace Orchard.MultiTenancy {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptor = new RouteDescriptor {
                Route = new Route(
                                                         "Admin/MultiTenancy/Edit/{name}",
                                                         new RouteValueDictionary {
                                                                                      {"area", "Orchard.MultiTenancy"},
                                                                                      {"controller", "Admin"},
                                                                                      {"action", "Edit"}
                                                                                  },
                                                                                      {"name", ".+"}
                                                                                      {"area", "Orchard.MultiTenancy"}
                                                         new MvcRouteHandler())
            };
            routes.Add(routeDescriptor);
        }
    }
}
