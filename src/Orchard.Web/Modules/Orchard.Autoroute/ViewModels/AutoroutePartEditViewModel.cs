using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Autoroute.Settings;
using System.Collections.Generic;

namespace Orchard.Autoroute.ViewModels {
    public class AutoroutePartEditViewModel {
        public AutorouteSettings Settings { get; set; }
        public bool IsHomePage { get; set; }
        public bool PromoteToHomePage { get; set; }
        public string CurrentUrl { get; set; }
        public string CustomPattern { get; set; }
        public string CurrentCulture { get; set; }
        public IEnumerable<string> SiteCultures { get; set; }
    }
}
