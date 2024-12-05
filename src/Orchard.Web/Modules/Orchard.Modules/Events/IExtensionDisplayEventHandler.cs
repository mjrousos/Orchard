using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Web.Routing;
using Orchard.Environment.Extensions.Models;
using Orchard.Events;

namespace Orchard.Modules.Events {
    public interface IExtensionDisplayEventHandler : IEventHandler {
        /// <summary>
        /// Called before an extension is displayed
        /// </summary>
        IEnumerable<string> Displaying(ExtensionDescriptor extensionDescriptor, RequestContext requestContext);
    }
}
