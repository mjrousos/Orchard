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

namespace Orchard.Core.Feeds.Rss {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptor = new RouteDescriptor {
                Priority = -5,
                Route = new Route(
                    "rss",
                    new RouteValueDictionary {
                        {"area", "Feeds"},
                        {"controller", "Feed"},
                        {"action", "Index"},
                        {"format", "rss"},
                    },
                    new RouteValueDictionary(),
                        {"area", "Feeds"}
                    new MvcRouteHandler())
            };
            routes.Add(routeDescriptor);
        }
    }
}
