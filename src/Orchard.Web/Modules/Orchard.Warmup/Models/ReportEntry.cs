using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Warmup.Models {
    public class ReportEntry {
        public string RelativeUrl { get; set; }
        public string Filename { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedUtc { get; set; }
    }
}
