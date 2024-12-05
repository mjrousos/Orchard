using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.MediaLibrary.Models;

namespace Orchard.MediaLibrary.Handlers {
    public class MediaLibrarySettingsPartHandler : ContentHandler {
        public MediaLibrarySettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<MediaLibrarySettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<MediaLibrarySettingsPart>("MediaLibrarySettings", "Parts/MediaLibrary.MediaLibrarySettings", "media"));
        }
        public Localizer T { get; set; }
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Media")));
    }
}
