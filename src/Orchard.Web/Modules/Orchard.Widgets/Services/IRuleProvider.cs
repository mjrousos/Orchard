using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Events;

namespace Orchard.Widgets.Services {
    [Obsolete("Use Orchard.Conditions.Services.IConditionProvider instead.")]
    public interface IRuleProvider : IEventHandler {
        void Process(RuleContext ruleContext);
    }
}
