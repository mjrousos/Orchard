using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Azure.MediaServices.Models;

namespace Orchard.Azure.MediaServices.ViewModels.Settings {
    public class EncodingSettingsViewModel {
        public IEnumerable<EncodingPreset> WamsEncodingPresets { get; set; }
        public int DefaultWamsEncodingPresetIndex { get; set; }
    }
}
