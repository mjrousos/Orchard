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

namespace Orchard.Lists {
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var routeDescriptors = new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "Admin/Lists/TreeViewSource",
                        new RouteValueDictionary {
                            {"area", "Orchard.Lists"},
                            {"controller", "AdminTreeView"},
                            {"action", "Nodes"}
                        },
                        new RouteValueDictionary(),
                            {"area", "Orchard.Lists"}
                        new MvcRouteHandler())
                },
                        "Admin/Lists/{containerId}/{filterByContentType}",
                            {"controller", "Admin"},
                            {"action", "List"},
                            {"filterByContentType", ""}
                        new RouteValueDictionary{
                            {"filterByContentType", @"\w*"},
                            {"containerId", @"\d+"}
                        "Admin/Lists/Choose/From/Orphaned/To/{targetContainerId}/{filterByContentType}",
                            {"action", "Choose"},
                            {"filterByContentType", ""},
                            {"sourceContainerId", "0"}
                            {"targetContainerId", @"\d+"},
                        "Admin/Lists/Choose/From/{sourceContainerId}/To/{targetContainerId}/{filterByContentType}",
                            {"sourceContainerId", @"\d+"},
            };
            foreach (var routeDescriptor in routeDescriptors) {
                routes.Add(routeDescriptor);
            }
        }
    }
}
