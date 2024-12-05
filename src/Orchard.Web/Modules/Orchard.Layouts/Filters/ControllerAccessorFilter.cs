using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.Layouts.Filters {
    public class ControllerAccessorFilter : FilterProvider, IActionFilter {
        public const string CurrentControllerKey = "CurrentController";
        public void OnActionExecuting(ActionExecutingContext filterContext) {
            filterContext.HttpContext.Items[CurrentControllerKey] = filterContext.Controller;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext) {}
    }
}
