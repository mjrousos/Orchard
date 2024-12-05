using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Routing;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Themes {
    public interface IThemeManager : IDependency {
        ExtensionDescriptor GetRequestTheme(RequestContext requestContext);
    }
}
