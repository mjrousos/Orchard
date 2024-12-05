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
    [OrchardFeature("Orchard.OpenId.Google")]
    public class GoogleSettingsPartHandler : ContentHandler {
        public Localizer T { get; set; }
        public GoogleSettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<GoogleSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<GoogleSettingsPart>("GoogleSettings", "Parts.GoogleSettings", "OpenId"));
        }
    }
}
