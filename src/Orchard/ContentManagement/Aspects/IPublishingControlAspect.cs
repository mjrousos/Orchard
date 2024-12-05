using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Utilities;

namespace Orchard.ContentManagement.Aspects {
    public interface IPublishingControlAspect {
        LazyField<DateTime?> ScheduledPublishUtc { get; }
    }
}
