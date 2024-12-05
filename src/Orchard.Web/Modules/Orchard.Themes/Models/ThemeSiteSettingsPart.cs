using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Themes.Models {
    public class ThemeSiteSettingsPart : ContentPart {
        public string CurrentThemeName {
            get { return this.Retrieve(x => x.CurrentThemeName); }
            set { this.Store(x => x.CurrentThemeName, value); }
        }
    }
}
