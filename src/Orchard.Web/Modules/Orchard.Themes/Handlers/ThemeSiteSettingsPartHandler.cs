using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Themes.Models;

namespace Orchard.Themes.Handlers {
    public class ThemeSiteSettingsPartHandler : ContentHandler {
        public ThemeSiteSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<ThemeSiteSettingsPart>("Site"));
        }
    }
}
