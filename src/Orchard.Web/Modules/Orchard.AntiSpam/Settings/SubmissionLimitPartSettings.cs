using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.AntiSpam.Settings {
    public class SubmissionLimitPartSettings {
        public int Limit { get; set; }
        public int Unit { get; set; }
    }

    public enum SubmissionLimitUnit {
        Hour,
        Day,
        Month,
        Year,
        Overall
}
