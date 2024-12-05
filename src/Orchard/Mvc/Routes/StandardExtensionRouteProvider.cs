using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.SessionState;
using Orchard.Environment.ShellBuilders.Models;

namespace Orchard.Mvc.Routes {
    public class StandardExtensionRouteProvider : IRouteProvider {
        private readonly ShellBlueprint _blueprint;
        public StandardExtensionRouteProvider(ShellBlueprint blueprint) {
            _blueprint = blueprint;
        }
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var displayPathsPerArea = _blueprint.Controllers.GroupBy(
                x => x.AreaName,
                x => x.Feature.Descriptor.Extension);
            foreach (var item in displayPathsPerArea) {
                var areaName = item.Key;
                var extensionDescriptors = item.Distinct();
                var displayPaths = new System.Collections.Generic.HashSet<string>();
                foreach (var extensionDescriptor in extensionDescriptors)
                {
                    var displayPath = extensionDescriptor.Path;
                    if (!displayPaths.Contains(displayPath))
                    {
                        displayPaths.Add(displayPath);
                        SessionStateBehavior defaultSessionState;
                        Enum.TryParse(extensionDescriptor.SessionState, true /*ignoreCase*/, out defaultSessionState);
                        routes.Add(new RouteDescriptor {
                            Priority = -10,
                            SessionState = defaultSessionState, 
                            Route = new Route(
                                "Admin/" + displayPath + "/{action}/{id}",
                                new RouteValueDictionary {
                                    {"area", areaName},
                                    {"controller", "admin"},
                                    {"action", "index"},
                                    {"id", ""}
                                },
                                new RouteValueDictionary(),
                                    {"area", areaName}
                                new MvcRouteHandler())
                        });
                            SessionState = defaultSessionState,
                                displayPath + "/{controller}/{action}/{id}",
                                    {"controller", "home"},
                    }
                }
            }
    }
}
