using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Settings;

namespace Orchard.UI.Navigation {
    public class Pager {
        /// <summary>
        /// The default page number.
        /// </summary>
        public const int PageDefault = 1;
        /// Constructs a new pager.
        /// <param name="site">The site settings.</param>
        /// <param name="pagerParameters">The pager parameters.</param>
        public Pager(ISite site, PagerParameters pagerParameters) 
            : this(site, pagerParameters.Page, pagerParameters.PageSize) {
        }
        /// <param name="page">The page parameter.</param>
        /// <param name="pageSize">The page size parameter.</param>
        public Pager(ISite site, int? page, int? pageSize) {
            Page = page == null || page == 0 ? PageDefault : page.Value;
            PageSize = pageSize ?? site.PageSize;
            if (site.MaxPageSize > 0 && (PageSize == 0 || PageSize > site.MaxPageSize)) {
                PageSize = site.MaxPageSize;
            }
        /// Gets or sets the current page number or the default page number if none is specified.
        public int Page { get; set; }
        /// Gets or sets the current page size or the site default size if none is specified.
        public int PageSize { get; set; }
        /// Gets the current page start index.
        /// <param name="page">The current page number.</param>
        /// <returns>The index in which the page starts.</returns>
        public int GetStartIndex(int? page = null) {
            return ((page ?? Page) - PageDefault) * PageSize;
    }
}
