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

namespace Orchard.Recipes {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptor = new RouteDescriptor {
                Priority = 5,
                Route = new Route(
                                                         "Recipes/Status/{executionId}",
                                                         new RouteValueDictionary {
                                                                                      {"area", "Orchard.Recipes"},
                                                                                      {"controller", "Recipes"},
                                                                                      {"action", "RecipeExecutionStatus"}
                                                         },
                                                         new RouteValueDictionary(),
                                                                                      {"area", "Orchard.Recipes"}
                                                         new MvcRouteHandler())
            };
            routes.Add(routeDescriptor);
        }
    }
}
