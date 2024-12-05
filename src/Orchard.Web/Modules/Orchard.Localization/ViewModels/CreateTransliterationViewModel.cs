using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Localization.ViewModels {
    public class CreateTransliterationViewModel {
        public string CultureFrom { get; set; }
        public string CultureTo { get; set; }
        public string Rules { get; set; }
    }
}
