using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.MediaLibrary.Settings {
    public class MediaLibraryPickerFieldSettings {
        public string Hint { get; set; }
        public bool Required { get; set; }
        public bool Multiple { get; set; }

        public string DisplayedContentTypes { get; set; }
    }
}
