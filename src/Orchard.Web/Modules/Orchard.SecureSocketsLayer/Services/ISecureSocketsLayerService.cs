using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using System.Web.Routing;
using Orchard.SecureSocketsLayer.Models;

namespace Orchard.SecureSocketsLayer.Services {
    public interface ISecureSocketsLayerService : IDependency {
        bool ShouldBeSecure(string actionName, string controllerName, RouteValueDictionary routeValues);
        bool ShouldBeSecure(RequestContext requestContext);
        bool ShouldBeSecure(ActionExecutingContext actionContext);
        string InsecureActionUrl(string actionName, string controllerName);
        string InsecureActionUrl(string actionName, string controllerName, object routeValues);
        string InsecureActionUrl(string actionName, string controllerName, RouteValueDictionary routeValues);
        string SecureActionUrl(string actionName, string controllerName);
        string SecureActionUrl(string actionName, string controllerName, object routeValues);
        string SecureActionUrl(string actionName, string controllerName, RouteValueDictionary routeValues);
        SslSettings GetSettings();
    }
}
