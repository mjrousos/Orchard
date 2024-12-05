using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;

namespace Orchard.Taxonomies.Settings {
    [OrchardFeature("Orchard.Taxonomies.LocalizationExtensions")]
    public class TaxonomyFieldLocalizationSettings {
        public bool TryToLocalize { get; set; }
        public TaxonomyFieldLocalizationSettings() {
            TryToLocalize = true; // default value
        }
    }
}
