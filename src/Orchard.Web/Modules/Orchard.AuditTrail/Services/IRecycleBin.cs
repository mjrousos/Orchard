using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Collections;

namespace Orchard.AuditTrail.Services {
    public interface IRecycleBin : IDependency {
        /// <summary>
        /// Returns all removed content items.
        /// </summary>
        IPageOfItems<ContentItem> List(int page, int pageSize);
        IPageOfItems<T> List<T>(int page, int pageSize) where T : class, IContent;
        /// Returns the specified list of content items from the recycle bin.
        IEnumerable<ContentItem> GetMany(IEnumerable<int> contentItemIds, QueryHints hints = null);
        IEnumerable<T> GetMany<T>(IEnumerable<int> contentItemIds, QueryHints hints = null) where T : class, IContent;
        /// Restores the specified content item.
        ContentItem Restore(ContentItem contentItem);
    }
}
