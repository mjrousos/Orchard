using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Orchard.MediaLibrary.WebSearch.Models;

namespace Orchard.MediaLibrary.WebSearch.Handlers {
    [OrchardFeature("Orchard.MediaLibrary.WebSearch.Pixabay")]
    public class PixabayWebSearchSettingsPartHandler : ContentHandler {
        public PixabayWebSearchSettingsPartHandler() {
            Filters.Add(new ActivatingFilter<PixabayWebSearchSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<PixabayWebSearchSettingsPart>("PixabayWebSearchSettings", "Parts/WebSearch.PixabayWebSearchSettings", "media"));
        }
    }
}
