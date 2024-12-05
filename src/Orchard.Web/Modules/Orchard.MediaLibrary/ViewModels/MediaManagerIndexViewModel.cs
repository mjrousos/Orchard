using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.MediaLibrary.Models;

namespace Orchard.MediaLibrary.ViewModels {
    public class MediaManagerIndexViewModel {
        public MediaManagerChildFoldersViewModel ChildFoldersViewModel { get; set; }
        public string FolderPath { get; set; }
        public string RootFolderPath { get; set; }
        public bool DialogMode { get; set; }
        public IEnumerable<ContentTypeDefinition> MediaTypes { get; set; }
        public dynamic CustomActionsShapes { get; set; }
        public dynamic CustomNavigationShapes { get; set; }
    }
}
