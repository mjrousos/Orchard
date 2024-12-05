using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Widgets.Services {
    [Obsolete("Use Orchard.Conditions.Services.IConditionManager instead.")]
    public interface IRuleManager : IDependency {
        bool Matches(string expression);
    }
}
