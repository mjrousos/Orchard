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

namespace Orchard.Search {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptors = new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route("Search/ContentPicker",
                        new RouteValueDictionary {
                            {"area", "Orchard.Search"},
                            {"controller", "ContentPicker"},
                            {"action", "Index"}
                        },
                        null,
                            {"area", "Orchard.Search"}
                        new MvcRouteHandler())
                },
                    Route = new Route("Search/{searchIndex}",
                            {"controller", "Search"},
                            {"action", "Index"},
                            {"searchIndex", UrlParameter.Optional}
                    Route = new Route("Admin/Search/BlogSearch/{blogId}",
                            {"controller", "BlogSearch"},
                            {"blogId", UrlParameter.Optional}
                }
            };
            foreach (var routeDescriptor in routeDescriptors)
                routes.Add(routeDescriptor);
        }
    }
}
