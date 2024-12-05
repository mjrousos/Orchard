using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Fields.Settings {
    public class NumericFieldSettings {
        public string Hint { get; set; }
        public bool Required { get; set; }
        public int Scale { get; set; }
        public decimal? Minimum { get; set; }
        public decimal? Maximum { get; set; }
        public string Placeholder { get; set; }
        public string DefaultValue { get; set; }

        public NumericFieldSettings() {
            Scale = 0;
        }
    }
}
