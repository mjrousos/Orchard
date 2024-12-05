using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Indexing.Services;

namespace Orchard.Indexing.ViewModels {
    public class IndexViewModel {
        public IIndexProvider IndexProvider { get; set; }
        public IEnumerable<IndexEntry> IndexEntries { get; set;}
    }
}
