using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Reports;

namespace Orchard.Core.Reports.ViewModels {
    public class ReportsAdminIndexViewModel  {
        public IList<Report> Reports { get; set; }
    }
}
