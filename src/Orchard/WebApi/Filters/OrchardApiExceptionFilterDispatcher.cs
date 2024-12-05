using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Orchard.WebApi.Filters {
    public class OrchardApiExceptionFilterDispatcher : IExceptionFilter {
        public bool AllowMultiple { get; private set; }
        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken) {
            var workContext = actionExecutedContext.ActionContext.ControllerContext.GetWorkContext();
            foreach (var exceptionFilter in workContext.Resolve<IEnumerable<IApiFilterProvider>>().OfType<IExceptionFilter>()) {
                await exceptionFilter.ExecuteExceptionFilterAsync(actionExecutedContext, cancellationToken);
            }
        }
    }
}
