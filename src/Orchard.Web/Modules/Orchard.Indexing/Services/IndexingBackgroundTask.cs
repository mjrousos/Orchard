using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Logging;
using Orchard.Tasks;

namespace Orchard.Indexing.Services {
    /// <summary>
    /// Regularly fires IIndexNotifierHandler events
    /// </summary>
    public class IndexingBackgroundTask : IBackgroundTask {
        private readonly IIndexNotifierHandler _indexNotifierHandler;
        private readonly IIndexManager _indexManager;
        public IndexingBackgroundTask(
            IIndexNotifierHandler indexNotifierHandler,
            IIndexManager indexManager) {
            _indexNotifierHandler = indexNotifierHandler;
            _indexManager = indexManager;
            Logger = NullLogger.Instance;
        }
        public ILogger Logger { get; set; }
        public void Sweep() {
            if (!_indexManager.HasIndexProvider()) {
                return;
            }
            foreach (var index in _indexManager.GetSearchIndexProvider().List()) {
                _indexNotifierHandler.UpdateIndex(index);
    }
}
