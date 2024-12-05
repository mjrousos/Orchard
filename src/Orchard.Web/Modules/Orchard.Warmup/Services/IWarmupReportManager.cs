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

namespace Orchard.Warmup.Services {
    public interface IWarmupReportManager : IDependency {
        IEnumerable<ReportEntry> Read();
        void Create(IEnumerable<ReportEntry> reportEntries);
    }
}
