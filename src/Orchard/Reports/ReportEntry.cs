using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Reports {
    public enum ReportEntryType {
        Information,
        Warning,
        Error
    }
    public class ReportEntry {
        public ReportEntryType Type { get; set; }
        public string Message { get; set; }
        public DateTime Utc { get; set; }
}
