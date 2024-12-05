using System;
using Microsoft.AspNetCore.Mvc;

namespace System.Web.Mvc
{
    public abstract class ControllerBase
    {
        protected ControllerBase()
        {
            ViewData = new ViewDataDictionary();
        }

        public ViewDataDictionary ViewData { get; set; }
        public TempDataDictionary TempData { get; set; }
        public UrlHelper Url { get; set; }
        public HttpContextBase HttpContext { get; set; }
        public RouteData RouteData { get; set; }
        public ControllerContext ControllerContext { get; set; }

        protected virtual void OnActionExecuting(ActionExecutingContext filterContext) { }
        protected virtual void OnActionExecuted(ActionExecutedContext filterContext) { }
        protected virtual void OnResultExecuting(ResultExecutingContext filterContext) { }
        protected virtual void OnResultExecuted(ResultExecutedContext filterContext) { }
    }

    public class ActionExecutingContext { }
    public class ActionExecutedContext { }
    public class ResultExecutingContext { }
    public class ResultExecutedContext { }
    public class RouteData { }
    public class ControllerContext { }
    public class TempDataDictionary : Dictionary<string, object> { }
}
