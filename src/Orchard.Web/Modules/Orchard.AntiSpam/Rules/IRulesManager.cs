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
using Orchard.Events;

namespace Orchard.AntiSpam.Rules {
    public interface IRulesManager : IEventHandler {
        void TriggerEvent(string category, string type, Func<Dictionary<string, object>> tokensContext);
    }
}
