using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Collections;
using Orchard.Indexing;

namespace Orchard.Search.Services {
    public interface ISearchService : IDependency {
        IPageOfItems<T> Query<T>(string query, int page, int? pageSize, bool filterCulture, string index, string[] searchFields, Func<ISearchHit, T> shapeResult);
    }
}
