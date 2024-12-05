using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.OutputCache.Services;
using Orchard.Tasks;

namespace Orchard.OutputCache.Services {
    [OrchardFeature("Orchard.OutputCache.Database")]
    public class DatabaseOutputCacheBackgroundTask : IBackgroundTask {
        private readonly IOutputCacheStorageProvider _outputCacheStorageProvider;
        public DatabaseOutputCacheBackgroundTask(IOutputCacheStorageProvider outputCacheStorageProvider) {
            _outputCacheStorageProvider = outputCacheStorageProvider;
        }
        public void Sweep() {
            var provider = _outputCacheStorageProvider as DatabaseOutputCacheStorageProvider;
            if (provider != null) {
                provider.RemoveExpiredEntries();
            }
    }
}
