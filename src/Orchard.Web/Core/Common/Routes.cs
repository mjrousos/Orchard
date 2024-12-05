using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Orchard.Core.Common {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptor = new RouteDescriptor {
                Priority = -9999,
                Route = new Route(
                        "{*path}",
                        new RouteValueDictionary {
                            {"area", "Common"},
                            {"controller", "Error"},
                            {"action", "NotFound"}
                        },
                            {"area", "Common"}
                        new MvcRouteHandler())
            };
            routes.Add(routeDescriptor);
        }
    }
}
