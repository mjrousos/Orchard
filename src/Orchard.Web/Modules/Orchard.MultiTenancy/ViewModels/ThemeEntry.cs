using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.MultiTenancy.ViewModels {
    public class ThemeEntry {
        public bool Checked { get; set; }
        public string ThemeName { get; set; }
        public string ThemeId { get; set; }
    }
}
