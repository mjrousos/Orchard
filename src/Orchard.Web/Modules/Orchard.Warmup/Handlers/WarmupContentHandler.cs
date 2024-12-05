using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Warmup.Models;
using Orchard.Warmup.Services;

namespace Orchard.Warmup.Handlers {
    /// <summary>
    /// Intercepts the ContentHandler events to create warmup static pages
    /// whenever some content is published
    /// </summary>
    public class WarmupContentHandler : ContentHandler {
        private readonly IOrchardServices _orchardServices;
        private readonly IWarmupScheduler _warmupScheduler;
        public WarmupContentHandler(IOrchardServices orchardServices, IWarmupScheduler warmupScheduler)
        {
            _orchardServices = orchardServices;
            _warmupScheduler = warmupScheduler;
            OnPublished<ContentPart>(Generate);
        }
        void Generate(PublishContentContext context, ContentPart part) {
            if(_orchardServices.WorkContext.CurrentSite.As<WarmupSettingsPart>().OnPublish) {
                _warmupScheduler.Schedule(true);
            }
    }
}
