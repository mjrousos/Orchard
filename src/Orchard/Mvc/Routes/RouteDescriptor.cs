using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web.Routing;
using System.Web.SessionState;

namespace Orchard.Mvc.Routes {
    public class RouteDescriptor {
        public string Name { get; set; }
        public int Priority { get; set; }
        public RouteBase Route { get; set; }
        public SessionStateBehavior SessionState { get; set; }
    }
    public class HttpRouteDescriptor : RouteDescriptor {
        public string RouteTemplate { get; set; }
        public object Defaults { get; set; }
        public object Constraints { get; set; }
}
