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
    public class MenuEditorViewModel {
        public IEnumerable<ContentItem> Menus { get; set; }
        public int CurrentMenuId { get; set; }
        public int StartLevel { get; set; }
        public int StopLevel { get; set; }
        public bool ShowFullMenu { get; set; }
    }
}
