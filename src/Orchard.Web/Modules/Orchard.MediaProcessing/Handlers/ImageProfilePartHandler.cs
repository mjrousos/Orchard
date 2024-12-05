using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Caching;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.MediaProcessing.Models;

namespace Orchard.MediaProcessing.Handlers {
    public class ImageProfilePartHandler : ContentHandler {
        private readonly ISignals _signals;
        public ImageProfilePartHandler(IRepository<ImageProfilePartRecord> repository, ISignals signals) {
            _signals = signals;
            Filters.Add(StorageFilter.For(repository));
        }
        protected override void Published(PublishContentContext context) {
            if (context.ContentItem.Has<ImageProfilePart>())
                _signals.Trigger("MediaProcessing_Published_" + context.ContentItem.As<ImageProfilePart>().Name);
            base.Published(context);
    }
}
