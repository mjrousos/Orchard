using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;

namespace Orchard.MediaLibrary.Settings {
    [OrchardFeature("Orchard.MediaLibrary.LocalizationExtensions")]
    public class MediaLibraryPickerFieldLocalizationSettings {
        public MediaLibraryPickerFieldLocalizationSettings() {
            TryToLocalizeMedia = true;
            RemoveItemsWithoutLocalization = false;
            RemoveItemsWithNoLocalizationPart = false; 
        }
        public bool TryToLocalizeMedia { get; set; }
        public bool RemoveItemsWithoutLocalization { get; set; }
        public bool RemoveItemsWithNoLocalizationPart { get; set; }
    }
}
