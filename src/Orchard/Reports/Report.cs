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

namespace Orchard.Reports {
    public class Report {
        public Report() {
            Entries = new List<ReportEntry>();
        }
        public IList<ReportEntry> Entries { get; set;}
        public int ReportId { get; set; }
        public string Title { get; set; }
        public string ActivityName { get; set; }
        public DateTime Utc { get; set; }
    }
}
