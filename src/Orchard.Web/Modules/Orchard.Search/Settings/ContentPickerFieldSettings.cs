using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Search.Settings {
    public class ContentPickerSearchFieldSettings {
        public ContentPickerSearchFieldSettings() {
            ShowSearchTab = true;
        }

        public bool ShowSearchTab { get; set; }
        public string SearchIndex { get; set; }
        public string DisplayedContentTypes { get; set; }
    }
}
