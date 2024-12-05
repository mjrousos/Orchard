using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.Caching;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Orchard.Tags.Models;
using Orchard.Tags.Services;

namespace Orchard.Tags.Handlers {
    [OrchardFeature("Orchard.Tags.TagCloud")]
    public class TagCloudHandler : ContentHandler {
        private readonly ISignals _signals;
        public TagCloudHandler(
            ITagCloudService tagCloudService,
            ISignals signals) {
            _signals = signals;
            OnInitializing<TagCloudPart>((context, part) => part
                ._tagCountField.Loader(() =>
                    tagCloudService.GetPopularTags(part.Buckets, part.Slug).ToList()
                    ));
            OnPublished<TagsPart>((context, part) => InvalidateTagCloudCache());
            OnRemoved<TagsPart>((context, part) => InvalidateTagCloudCache());
            OnUnpublished<TagsPart>((context, part) => InvalidateTagCloudCache());
        }
        public void InvalidateTagCloudCache() {
            _signals.Trigger(TagCloudService.TagCloudTagsChanged);
    }
}
