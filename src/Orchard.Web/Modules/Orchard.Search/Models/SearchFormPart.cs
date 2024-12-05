using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Search.Models {
    /// <summary>
    /// Content part for the search form widget
    /// </summary>
    public class SearchFormPart : ContentPart {
        public bool OverrideIndex {
            get { return this.Retrieve(x => x.OverrideIndex); }
            set { this.Store(x => x.OverrideIndex, value); }
        }
        public string SelectedIndex {
            get { return this.Retrieve(x => x.SelectedIndex); }
            set { this.Store(x => x.SelectedIndex, value); }
    }
}
