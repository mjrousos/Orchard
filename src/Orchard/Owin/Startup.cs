using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Owin;

namespace Orchard.Owin {
    /// <summary>
    /// The entry point for the Owin pipeline that doesn't really do anything on its own but is necessary for bootstrapping.
    /// </summary>
    /// <remarks>Also, startups are hip nowadays.</remarks>
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.Use((context, next) => {
                context.Response.Headers.Append("X-Generator", "Orchard");
                return next();
            });
        }
    }
}
