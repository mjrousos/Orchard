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
using System.Text;
using System.Web.Http.Routing;
using System.Web.Routing;

namespace Orchard.WebApi.Extensions {
    public static class RouteExtension {
        public static string GetAreaName(this IHttpRoute route){
            var routeWithArea = route as IRouteWithArea;
            if (routeWithArea != null) {
                return routeWithArea.Area;
            }
            var castRoute = route as Route;
            if (castRoute != null && castRoute.DataTokens != null) {
                return castRoute.DataTokens["area"] as string;
            return null;
        }
        public static string GetAreaName(this IHttpRouteData routeData) {
            object area;
            if (routeData.Route.Defaults.TryGetValue("area", out area)) {
                return area as string;
            return GetAreaName(routeData.Route);
    }
}
