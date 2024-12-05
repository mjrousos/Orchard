using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data;
using Orchard.ContentManagement.Handlers;
using Orchard.Tags.Models;
using Orchard.Tags.Services;

namespace Orchard.Tags.Handlers {
    public class TagsPartHandler : ContentHandler {
        public TagsPartHandler(IRepository<TagsPartRecord> repository, ITagService tagService) {
            Filters.Add(StorageFilter.For(repository));
 
            OnRemoved<TagsPart>((context, tags) => 
                tagService.RemoveTagsForContentItem(context.ContentItem));
            OnIndexing<TagsPart>(
                (context, tagsPart) => {
                    foreach (var tag in tagsPart.CurrentTags) {
                        context.DocumentIndex.Add("tags", tag).Analyze();
                    }
                });
        }
    }
}
