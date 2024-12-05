using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Localization.ViewModels {
    public class EditLocalizationViewModel  {
        public string SelectedCulture { get; set; }
        public IEnumerable<string> MissingCultures { get; set; }
        public IContent ContentItem { get; set; }
        public IContent MasterContentItem { get; set; }
        public ContentLocalizationsViewModel ContentLocalizations { get; set; }
        public bool DisplayLanguageSelection { get; set; }
    }
}
