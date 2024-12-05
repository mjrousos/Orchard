using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using Orchard.Mvc.Routes;
using Orchard.OpenId.Services;

namespace Orchard.Azure.Authentication {
    public class OpenIdRoutes : IRouteProvider {
        private readonly IEnumerable<IOpenIdProvider> _openIdProviders;
        public OpenIdRoutes(IEnumerable<IOpenIdProvider> openIdProviders) {
            _openIdProviders = openIdProviders;
        }
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            if (IsAnyProviderSettingsValid() == false)
                return;
            var routeDescriptors = new[] {
                new RouteDescriptor {
                    Priority = 11,
                    Route = new Route(
                        "Users/Account/Challenge/{openIdProvider}",
                        new RouteValueDictionary {
                            {"area", "Orchard.OpenId"},
                            {"controller", "Account"},
                            {"action", "Challenge"}
                        },
                        new RouteValueDictionary(),
                        new MvcRouteHandler())
                },
                    Priority = 10,
                        "Users/Account/{action}",
                            {"controller", "Account"}
                        "Authentication/Error/",
                            { "action", "Error" }
                }
            };
            foreach (var routeDescriptor in routeDescriptors) {
                routes.Add(routeDescriptor);
            }
        private bool IsAnyProviderSettingsValid() {
            return _openIdProviders.Any(provider => provider.IsValid);
    }
}
