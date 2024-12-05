using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Indexing.Services {
    public enum IndexingStatus {
        Rebuilding,
        Updating,
        Idle,
        Unavailable
    }
    public interface IIndexStatisticsProvider : IDependency {
        DateTime GetLastIndexedUtc(string indexName);
        IndexingStatus GetIndexingStatus(string indexName);
}
