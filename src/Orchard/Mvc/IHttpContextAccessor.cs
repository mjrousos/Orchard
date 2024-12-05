using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;

namespace Orchard.Mvc {
    public interface IHttpContextAccessor {
        HttpContextBase Current();
        void Set(HttpContextBase httpContext);
    }
}
