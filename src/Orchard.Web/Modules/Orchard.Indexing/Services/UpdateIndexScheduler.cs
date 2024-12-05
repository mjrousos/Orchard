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
using Orchard.Environment.Configuration;
using Orchard.Environment.Descriptor;
using Orchard.Environment.State;

namespace Orchard.Indexing.Services {
    public class UpdateIndexScheduler : IUpdateIndexScheduler, IIndexNotifierHandler {
        private readonly IProcessingEngine _processingEngine;
        private readonly ShellSettings _shellSettings;
        private readonly IShellDescriptorManager _shellDescriptorManager;
        private readonly Lazy<IIndexingTaskExecutor> _indexingTaskExecutor;
        public UpdateIndexScheduler(
            IProcessingEngine processingEngine,
            ShellSettings shellSettings,
            IShellDescriptorManager shellDescriptorManager,
            Lazy<IIndexingTaskExecutor> indexingTaskExecutor
            ) {
            _processingEngine = processingEngine;
            _shellSettings = shellSettings;
            _shellDescriptorManager = shellDescriptorManager;
            _indexingTaskExecutor = indexingTaskExecutor;
        }
        public void Schedule(string indexName) {
            var shellDescriptor = _shellDescriptorManager.GetShellDescriptor();
            _processingEngine.AddTask(
                _shellSettings,
                shellDescriptor,
                "IIndexNotifierHandler.UpdateIndex",
                new Dictionary<string, object> { { "indexName", indexName } }
            );
        public void UpdateIndex(string indexName) {
            if(_indexingTaskExecutor.Value.UpdateIndexBatch(indexName)) {
                Schedule(indexName);
            }
    }
}
