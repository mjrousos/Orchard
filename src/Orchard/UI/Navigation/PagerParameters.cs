using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.UI.Navigation {
    public class PagerParameters {
        /// <summary>
        /// Gets or sets the current page number or null if none specified.
        /// </summary>
        public int? Page { get; set; }

        /// Gets or sets the current page size or null if none specified.
        public int? PageSize { get; set; }
    }
}
