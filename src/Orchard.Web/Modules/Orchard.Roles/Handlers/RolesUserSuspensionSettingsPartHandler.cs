using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Roles.Models;

namespace Orchard.Roles.Handlers {
    public class RolesUserSuspensionSettingsPartHandler : ContentHandler {
        public RolesUserSuspensionSettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<RolesUserSuspensionSettingsPart>("Site"));
        }
        public Localizer T { get; set; }
    }
}
