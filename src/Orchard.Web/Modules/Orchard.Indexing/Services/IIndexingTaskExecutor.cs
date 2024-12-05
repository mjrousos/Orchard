using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Indexing.Services {
    public interface IIndexingTaskExecutor : IDependency {
        bool DeleteIndex(string indexName);
        bool RebuildIndex(string indexName);
        bool UpdateIndexBatch(string indexName);
    }
}
