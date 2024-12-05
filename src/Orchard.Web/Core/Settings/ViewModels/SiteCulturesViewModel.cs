using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Core.Settings.ViewModels {
    public class SiteCulturesViewModel  {
        public string CurrentCulture { get; set; }
        public IEnumerable<string> SiteCultures { get; set; }
        public IEnumerable<string> AvailableSystemCultures { get; set; }
    }
}
