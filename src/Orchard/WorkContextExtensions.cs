using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;
using System.Web.Http.Controllers;
using System.Web.Routing;
using Autofac;

namespace Orchard {
    public static class WorkContextExtensions {
        public static WorkContext GetContext(this IWorkContextAccessor workContextAccessor, ControllerContext controllerContext) {
            return workContextAccessor.GetContext(controllerContext.RequestContext.HttpContext);
        }
        public static WorkContext GetLogicalContext(this IWorkContextAccessor workContextAccessor) {
            var wca = workContextAccessor as ILogicalWorkContextAccessor;
            return wca != null ? wca.GetLogicalContext() : null;
        public static WorkContext GetWorkContext(this RequestContext requestContext) {
            if (requestContext == null)
                return null;
            var routeData = requestContext.RouteData;
            if (routeData == null || routeData.DataTokens == null)
            
            object workContextValue;
            if (!routeData.DataTokens.TryGetValue("IWorkContextAccessor", out workContextValue)) {
                workContextValue = FindWorkContextInParent(routeData);
            }
            if (!(workContextValue is IWorkContextAccessor))
            var workContextAccessor = (IWorkContextAccessor)workContextValue;
            return workContextAccessor.GetContext(requestContext.HttpContext);
        public static WorkContext GetWorkContext(this HttpControllerContext controllerContext) {
            if (controllerContext == null)
            var routeData = controllerContext.RouteData;
            if (routeData == null || routeData.Values == null)
            if (!routeData.Values.TryGetValue("IWorkContextAccessor", out workContextValue)) {
            if (workContextValue == null || !(workContextValue is IWorkContextAccessor))
            return workContextAccessor.GetContext();
        private static object FindWorkContextInParent(RouteData routeData) {
            object parentViewContextValue;
            if (!routeData.DataTokens.TryGetValue("ParentActionViewContext", out parentViewContextValue)
                || !(parentViewContextValue is ViewContext)) {
            var parentRouteData = ((ViewContext)parentViewContextValue).RouteData;
            if (parentRouteData == null || parentRouteData.DataTokens == null)
            if (!parentRouteData.DataTokens.TryGetValue("IWorkContextAccessor", out workContextValue)) {
                workContextValue = FindWorkContextInParent(parentRouteData);
            return workContextValue;
        public static WorkContext GetWorkContext(this ControllerContext controllerContext) {
            return GetWorkContext(controllerContext.RequestContext);
        public static IWorkContextScope CreateWorkContextScope(this ILifetimeScope lifetimeScope, HttpContextBase httpContext) {
            return lifetimeScope.Resolve<IWorkContextAccessor>().CreateWorkContextScope(httpContext);
        public static IWorkContextScope CreateWorkContextScope(this ILifetimeScope lifetimeScope) {
            return lifetimeScope.Resolve<IWorkContextAccessor>().CreateWorkContextScope();
    }
}
