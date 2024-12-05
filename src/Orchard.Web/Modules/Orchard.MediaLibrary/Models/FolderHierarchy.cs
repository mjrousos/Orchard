using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.MediaLibrary.Models {
    public class FolderHierarchy  {
        public FolderHierarchy(IMediaFolder root) {
            Root = root;
            Children = new List<FolderHierarchy>();
        }
        public IMediaFolder Root { get; set; }
        public IEnumerable<FolderHierarchy> Children { get; set; }
    }
}
