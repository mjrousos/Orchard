using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Azure.MediaServices.Models;
using Orchard.ContentManagement.Handlers;

namespace Orchard.Azure.MediaServices.Handlers {
    public class CloudMediaSettingsPartHandler : ContentHandler {
        public CloudMediaSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<CloudMediaSettingsPart>("Site"));
        }
    }
}
