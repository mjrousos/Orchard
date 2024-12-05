using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Tasks;
using Orchard.Warmup.Models;

namespace Orchard.Warmup.Services {
    public class WarmupTask : IBackgroundTask {
        private readonly IOrchardServices _orchardServices;
        private readonly IWarmupUpdater _warmupUpdater;
        public WarmupTask(IOrchardServices orchardServices, IWarmupUpdater warmupUpdater) {
            _orchardServices = orchardServices;
            _warmupUpdater = warmupUpdater;
        }
        public void Sweep() {
            var part = _orchardServices.WorkContext.CurrentSite.As<WarmupSettingsPart>();
            if (!part.Scheduled) {
                return;
            }
            _warmupUpdater.EnsureGenerate();
    }
}
