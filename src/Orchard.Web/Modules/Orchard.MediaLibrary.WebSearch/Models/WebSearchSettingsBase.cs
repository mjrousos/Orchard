using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.MediaLibrary.WebSearch.Models {
    public abstract class WebSearchSettingsBase : ContentPart, IWebSearchSettings {
        public string ApiKey {
            get => this.Retrieve(x => x.ApiKey);
            set => this.Store(x => x.ApiKey, value);
        }
    }
}
