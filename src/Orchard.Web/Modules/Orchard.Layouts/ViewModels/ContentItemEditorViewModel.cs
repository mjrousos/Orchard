using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Layouts.ViewModels {
    public class ContentItemEditorViewModel {
        public string ContentItemIds { get; set; }
        public IList<ContentItem> ContentItems { get; set; }
        public string DisplayType { get; set; }
    }
}
