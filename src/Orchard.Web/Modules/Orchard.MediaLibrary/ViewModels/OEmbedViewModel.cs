using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.MediaLibrary.Models;
using System.Xml.Linq;

namespace Orchard.MediaLibrary.ViewModels {
    public class OEmbedViewModel {
        public string FolderPath { get; set; }
        public string Url { get; set; }
        public XDocument Content { get; set; }
        public MediaPart Replace { get; set; }
    }
}
