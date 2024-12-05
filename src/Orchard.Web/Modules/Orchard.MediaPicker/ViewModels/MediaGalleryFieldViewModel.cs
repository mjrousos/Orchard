using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.MediaPicker.Fields;

namespace Orchard.MediaPicker.ViewModels {
    public class MediaGalleryFieldViewModel {
        public ICollection<MediaGalleryItem> Items { get; set; }
        public string SelectedItems { get; set; }
        public MediaGalleryField Field { get; set; }
    }
}
