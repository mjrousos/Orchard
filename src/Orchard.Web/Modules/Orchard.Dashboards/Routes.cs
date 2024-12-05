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

namespace Orchard.Dashboards {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptors = new[] {
                new RouteDescriptor {
                    Priority = -4,
                    Route = new Route(
                        "Admin",
                        new RouteValueDictionary {
                            {"area", "Orchard.Dashboards"},
                            {"controller", "Dashboard"},
                            {"action", "Display"}
                        },
                        new RouteValueDictionary(),
                            {"area", "Orchard.Dashboards"}
                        new MvcRouteHandler())
                },
                    "Admin/Dashboards/Settings",
                    new RouteValueDictionary {
                        {"area", "Orchard.Dashboards"},
                        {"controller", "Settings"},
                        {"action", "Index"}
                    },
                    new RouteValueDictionary(),
                        {"area", "Orchard.Dashboards"}
                    new MvcRouteHandler())
                    "Admin/Dashboards/List",
                        {"controller", "Dashboard"},
                        {"action", "List"}
                }
            };
            foreach (var routeDescriptor in routeDescriptors)
                routes.Add(routeDescriptor);
        }
    }
}
