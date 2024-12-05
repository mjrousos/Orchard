using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Orchard.MediaLibrary.WebSearch.Models {
    [OrchardFeature("Orchard.MediaLibrary.WebSearch.Google")]
    public class GoogleWebSearchSettingsPart : WebSearchSettingsBase {
        public string SearchEngineId {
            get => this.Retrieve(x => x.SearchEngineId);
            set => this.Store(x => x.SearchEngineId, value);
        }
    }
}
