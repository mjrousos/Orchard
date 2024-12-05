using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Taxonomies.Settings {
    public class TermPartSettings {
        /// <summary>
        /// The display type to use for the child items of the term.
        /// </summary>
        public string ChildDisplayType { get; set; }

        /// If true, overrides default pagination settings with the PageSize value.
        public bool OverrideDefaultPagination { get; set; }
        /// The page size, if OverrideDefaultPagination is set to true.
        public int PageSize { get; set; }
    }
}
