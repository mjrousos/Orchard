using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.Tasks;

namespace Orchard.Alias.Implementation.Updater {
    [OrchardFeature("Orchard.Alias.Updater")]
    public class AliasUpdaterBackgroundTask : IBackgroundTask {
        private readonly IAliasHolderUpdater _aliasHolderUpdater;
        public AliasUpdaterBackgroundTask(IAliasHolderUpdater aliasHolderUpdater) {
            _aliasHolderUpdater = aliasHolderUpdater;
        }
        public void Sweep() {
            _aliasHolderUpdater.Refresh();
    }
}
