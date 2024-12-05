using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Themes.Models;

namespace Orchard.Themes.ViewModels {
    public class ThemesIndexViewModel {
        public bool InstallThemes { get; set; }
        public ThemeEntry CurrentTheme { get; set; }
        public IEnumerable<ThemeEntry> Themes { get; set; }
    }
}
