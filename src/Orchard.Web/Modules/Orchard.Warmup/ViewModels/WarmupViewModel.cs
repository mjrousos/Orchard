using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Warmup.Models;

namespace Orchard.Warmup.ViewModels {
    public class WarmupViewModel {
        public WarmupSettingsPart Settings { get; set; }
        public IEnumerable<ReportEntry> ReportEntries { get; set; }
    }
}
