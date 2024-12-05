using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Indexing;

namespace Orchard.Search.ViewModels {
    public class SearchResultViewModel {
        public ISearchHit SearchHit { get; set; }
        public IContent Content { get; set; }
    }
}
