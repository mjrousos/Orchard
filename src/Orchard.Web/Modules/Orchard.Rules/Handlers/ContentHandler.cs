using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.Handlers;
using Orchard.Rules.Services;

namespace Orchard.Rules.Handlers {
    public class RulePartHandler : ContentHandler {
        public RulePartHandler(IRulesManager rulesManager) {
            OnPublished<ContentPart>(
                (context, part) =>
                    rulesManager.TriggerEvent("Content", "Published",
                    () => new Dictionary<string, object> { { "Content", context.ContentItem } }));
            OnRemoved<ContentPart>(
                    rulesManager.TriggerEvent("Content", "Removed",
            OnVersioned<ContentPart>(
                (context, part1, part2) =>
                    rulesManager.TriggerEvent("Content", "Versioned",
                    () => new Dictionary<string, object> { { "Content", part1.ContentItem } }));
            OnCreated<ContentPart>(
                    rulesManager.TriggerEvent("Content", "Created",
        }
    }
}
