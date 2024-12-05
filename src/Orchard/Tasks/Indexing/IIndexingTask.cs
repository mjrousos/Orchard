using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Tasks.Indexing {
    public interface IIndexingTask {
        ContentItem ContentItem { get; }
        DateTime? CreatedUtc { get; }
    }
}
