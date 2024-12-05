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
    [OrchardFeature("Orchard.OpenId.ActiveDirectoryFederationServices")]
    public class ActiveDirectoryFederationServicesSettingsPartHandler : ContentHandler {
        public Localizer T { get; set; }
        public ActiveDirectoryFederationServicesSettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<ActiveDirectoryFederationServicesSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<ActiveDirectoryFederationServicesSettingsPart>("ActiveDirectoryFederationServicesSettings", "Parts.ActiveDirectoryFederationServicesSettings", "OpenId"));
        }
    }
}
