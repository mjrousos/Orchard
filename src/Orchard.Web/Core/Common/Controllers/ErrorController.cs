using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using Orchard.Themes;

namespace Orchard.Core.Common.Controllers {
    [Themed]
    public class ErrorController : Controller {
        public ActionResult NotFound(string url) {
            return HttpNotFound();
        }
    }
}
