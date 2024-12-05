using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using Orchard.Alias.Implementation;
using Orchard.Alias.Implementation.Holder;
using Orchard.Environment.ShellBuilders.Models;
using Orchard.Mvc.Routes;

namespace Orchard.Alias {
    public class Routes : IRouteProvider {
        private readonly ShellBlueprint _blueprint;
        private readonly IAliasHolder _aliasHolder;
        public Routes(ShellBlueprint blueprint, IAliasHolder aliasHolder) {
            _blueprint = blueprint;
            _aliasHolder = aliasHolder;
        }
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            var distinctAreaNames = _blueprint.Controllers
                .Select(controllerBlueprint => controllerBlueprint.AreaName)
                .Distinct();
            var routeDescriptors = distinctAreaNames.Select(areaName =>
                 new RouteDescriptor {
                     Priority = 80,
                     Route = new AliasRoute(_aliasHolder, areaName, new MvcRouteHandler())
                 }).ToList();
            foreach (var routeDescriptor in routeDescriptors) {
                routes.Add(routeDescriptor);
            }
    }
}
