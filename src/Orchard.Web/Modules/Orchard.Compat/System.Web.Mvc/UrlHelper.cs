using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace System.Web.Mvc
{
    public class UrlHelper
    {
        private readonly IUrlHelper _aspNetCoreUrlHelper;
        private readonly HttpContext _httpContext;

        public UrlHelper(RequestContext requestContext)
        {
            _httpContext = requestContext?.HttpContext?.Items["Microsoft.AspNetCore.Http.HttpContext"] as HttpContext;
        }

        public string Action(string actionName)
        {
            return _aspNetCoreUrlHelper?.Action(actionName) ?? $"/{actionName}";
        }

        public string Action(string actionName, string controllerName)
        {
            return _aspNetCoreUrlHelper?.Action(actionName, controllerName) ?? $"/{controllerName}/{actionName}";
        }

        public string Action(string actionName, object routeValues)
        {
            return _aspNetCoreUrlHelper?.Action(actionName, routeValues) ?? $"/{actionName}";
        }

        public string Action(string actionName, string controllerName, object routeValues)
        {
            return _aspNetCoreUrlHelper?.Action(actionName, controllerName, routeValues) ?? $"/{controllerName}/{actionName}";
        }

        public string Content(string contentPath)
        {
            return _aspNetCoreUrlHelper?.Content(contentPath) ?? contentPath;
        }

        public string RouteUrl(object routeValues)
        {
            return _aspNetCoreUrlHelper?.RouteUrl(routeValues) ?? "/";
        }

        public string RouteUrl(string routeName, object routeValues)
        {
            return _aspNetCoreUrlHelper?.RouteUrl(routeName, routeValues) ?? "/";
        }
    }

    public class RequestContext
    {
        public HttpContextBase HttpContext { get; set; }
        public RouteData RouteData { get; set; }
    }
}
