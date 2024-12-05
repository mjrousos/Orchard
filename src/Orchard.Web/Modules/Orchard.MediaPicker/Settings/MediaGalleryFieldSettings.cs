using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.MediaPicker.Settings {
    public class MediaGalleryFieldSettings {
        public string Hint { get; set; }
        public string AllowedExtensions { get; set; }
        public bool Required { get; set; }
        public bool Multiple { get; set; }
    }
}
