using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;

namespace Orchard.Localization.Settings {
    [OrchardFeature("Orchard.Localization.CultureNeutralPartsAndFields")]
    public class LocalizationCultureNeutralitySettings {
        public bool CultureNeutral { get; set; } //this setting applies to both parts and fields, and can be controlled during type definition
    }
}
