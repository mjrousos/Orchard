using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;
using System.Web.Routing;
using Orchard.Specs.Hosting.Orchard.Web;

namespace Orchard.Specs.Hosting.Simple.Web {
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var route = RouteTable.Routes.MapRoute("foo", "hello-world", new { controller = "Home", action = "Index" });
            route.RouteHandler = new HelloYetAgainHandler();
        }
    }
}
