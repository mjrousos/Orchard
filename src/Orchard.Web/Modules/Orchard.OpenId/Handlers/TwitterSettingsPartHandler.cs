using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Orchard.OpenId.Models;

namespace Orchard.OpenId.Handlers {
    [OrchardFeature("Orchard.OpenId.Twitter")]
    public class TwitterSettingsPartHandler : ContentHandler {
        public Localizer T { get; set; }
        public TwitterSettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<TwitterSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<TwitterSettingsPart>("TwitterSettings", "Parts.TwitterSettings", "OpenId"));
        }
    }
}
