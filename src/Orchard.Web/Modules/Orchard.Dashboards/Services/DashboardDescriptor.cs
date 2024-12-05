using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Dashboards.Services {
    public class DashboardDescriptor {
        public int Priority { get; set; }
        public Func<dynamic, dynamic> Display { get; set; }
        public Func<dynamic, dynamic> Editor { get; set; }
        public Func<dynamic, IUpdateModel, dynamic> UpdateEditor { get; set; }
    }
}
