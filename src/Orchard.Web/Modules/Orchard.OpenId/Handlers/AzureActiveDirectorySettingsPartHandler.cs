using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.OpenId.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Orchard.OpenId.Handlers {
    [OrchardFeature("Orchard.OpenId.AzureActiveDirectory")]
    public class AzureActiveDirectorySettingsPartHandler : ContentHandler {
        public Localizer T { get; set; }
        public AzureActiveDirectorySettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<AzureActiveDirectorySettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<AzureActiveDirectorySettingsPart>("AzureActiveDirectorySettings", "Parts.AzureActiveDirectorySettings", "OpenId"));
        }
    }
}
