using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web;

namespace Orchard.Time {
    public interface ITimeZoneSelector : IDependency {
        TimeZoneSelectorResult GetTimeZone(HttpContextBase context);
    }
}
