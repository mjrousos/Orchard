using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Azure.MediaServices.ViewModels.Settings {
    public class SubtitleLanguagesSettingsViewModel {
        public IEnumerable<string> Languages { get; set; }
    }
}
