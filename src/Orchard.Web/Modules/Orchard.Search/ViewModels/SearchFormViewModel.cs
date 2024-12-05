using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Search.ViewModels {
    public class SearchFormViewModel {
        public bool OverrideIndex { get; set; }
        public string SelectedIndex { get; set; }
        public IList<string> AvailableIndexes { get; set; }
    }
}
