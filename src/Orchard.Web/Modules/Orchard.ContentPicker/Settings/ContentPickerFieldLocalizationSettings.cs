using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;

namespace Orchard.ContentPicker.Settings {
    [OrchardFeature("Orchard.ContentPicker.LocalizationExtensions")]
    public class ContentPickerFieldLocalizationSettings {
        public ContentPickerFieldLocalizationSettings() {
            TryToLocalizeItems = true;
        }
        public bool TryToLocalizeItems { get; set; }
        public bool RemoveItemsWithoutLocalization { get; set; }
        public bool RemoveItemsWithNoLocalizationPart { get; set; }
        public bool AssertItemsHaveSameCulture { get; set; }
        public bool BlockForItemsWithNoLocalizationPart { get; set; }
    }
}
