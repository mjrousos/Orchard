using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Linq;
using Orchard.Environment;

namespace Orchard.Mvc.ViewEngines.ThemeAwareness {
    public class ThemeAwareViewEngineShim : IViewEngine, IShim {
        public ThemeAwareViewEngineShim() {
            OrchardHostContainerRegistry.RegisterShim(this);
        }
        public IOrchardHostContainer HostContainer { get; set; }
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache) {
            return Forward(
                controllerContext,
                dve => dve.FindPartialView(controllerContext, partialViewName, useCache, false /*useDeepPaths*/),
                EmptyViewEngineResult);
        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache) {
                dve => dve.FindView(controllerContext, viewName, masterName, useCache, false /*useDeepPaths*/),
        public void ReleaseView(ControllerContext controllerContext, IView view) {
            throw new NotImplementedException();
        static TResult Forward<TResult>(ControllerContext controllerContext, Func<IThemeAwareViewEngine, TResult> forwardAction, Func<TResult> defaultAction) {
            var workContext = controllerContext.GetWorkContext();
            if (workContext != null) {
                var displayViewEngine = workContext.Resolve<IThemeAwareViewEngine>();
                if (displayViewEngine != null) {
                    return forwardAction(displayViewEngine);
                }
            }
            return defaultAction();
        static ViewEngineResult EmptyViewEngineResult() {
            return new ViewEngineResult(Enumerable.Empty<string>());
    }
}
