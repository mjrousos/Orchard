using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Users.Services {
    public interface IUserManagementActionsProvider : IDependency {
        // Using a delegate so implementations don't have to build/figure out
        // their own HtmlHelper
        IEnumerable<Func<HtmlHelper, MvcHtmlString>> UserActionLinks(IUser user);
    }
}
