using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;

namespace Orchard.Indexing.Services {
    public class IndexEntry {
        public string IndexName { get; set; }
        public int DocumentCount { get; set; }
        public DateTime LastUpdateUtc { get; set; }
        public IEnumerable<string> Fields { get; set; }
        public IndexingStatus IndexingStatus { get; set; }
    }
    public interface IIndexingService : IDependency {
        void DeleteIndex(string indexName);
        void RebuildIndex(string indexName);
        void UpdateIndex(string indexName);
        IndexEntry GetIndexEntry(string indexName);
}
