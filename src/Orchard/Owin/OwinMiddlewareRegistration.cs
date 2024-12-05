using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Owin;

namespace Orchard.Owin {
    /// <summary>
    /// An Owin middleware registration that can make changes to the Owin pipeline, like registering middlewares to be injected into the Orchard 
    /// Owin pipeline.
    /// </summary>
    public class OwinMiddlewareRegistration {
        /// <summary>
        /// Gets or sets the delegate that you can use to make changes to the Owin pipeline, like registering middlewares to be injected into
        /// the Orchard Owin pipeline.
        /// </summary>
        public Action<IAppBuilder> Configure { get; set; }
        /// Gets or sets the priority value that decides the order in which such objects are processed. I.e. "0" will run before "10", 
        /// but registrations without a priority value will run before the ones that have it set.
        /// Note that this priority notation is the same as the one for shape placement (so you can e.g. use ":before").
        public string Priority { get; set; }
    }
}
