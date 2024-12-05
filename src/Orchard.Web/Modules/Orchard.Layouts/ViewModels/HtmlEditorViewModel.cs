using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Layouts.ViewModels {
    public class HtmlEditorViewModel {
        public string Text { get; set; }
        public ContentPart Part { get; set; }
    }
}
