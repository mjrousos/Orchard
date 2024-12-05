using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Autoroute.Settings {

    /// <summary>
    /// Models the Default Patterns you can choose from
    /// </summary>
    public class DefaultPattern {
        public string Culture { get; set; }
        public string PatternIndex { get; set; }
    }
}
