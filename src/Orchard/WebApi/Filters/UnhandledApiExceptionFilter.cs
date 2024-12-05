using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Threading.Tasks;
using System.Web.Http.Filters;
using Orchard.Logging;

namespace Orchard.WebApi.Filters {
    public class UnhandledApiExceptionFilter : ExceptionFilterAttribute, IApiFilterProvider {
        public UnhandledApiExceptionFilter() {
            Logger = NullLogger.Instance;
        }
        public ILogger Logger { get; set; }
        public override void OnException(HttpActionExecutedContext actionExecutedContext) {
            if (actionExecutedContext.Exception is TaskCanceledException)
                Logger.Warning(actionExecutedContext.Exception, "A pending API operation was canceled by the client.");
            else
                Logger.Error(actionExecutedContext.Exception, "An unhandled exception was thrown in an API operation.");
    }
}
