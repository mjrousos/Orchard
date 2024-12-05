using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Records;

namespace Orchard.MediaLibrary.Models {
    public class MediaPartRecord : ContentPartRecord {
        public virtual string MimeType { get; set; }
        public virtual string Caption { get; set; }
        public virtual string AlternateText { get; set; }
        public virtual string FolderPath { get; set; }
        public virtual string FileName { get; set; }
    }
}
