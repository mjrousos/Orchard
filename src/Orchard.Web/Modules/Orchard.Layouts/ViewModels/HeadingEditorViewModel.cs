using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Layouts.ViewModels {
    public class HeadingEditorViewModel {
        public string Text { get; set; }
        public int Level { get; set; }
    }
}
