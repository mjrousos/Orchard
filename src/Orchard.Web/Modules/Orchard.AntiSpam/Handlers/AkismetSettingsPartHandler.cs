using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AntiSpam.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;

namespace Orchard.AntiSpam.Handlers {
    [OrchardFeature("Akismet.Filter")]
    public class AkismetSettingsPartHandler : ContentHandler {
        public AkismetSettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<AkismetSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<AkismetSettingsPart>("AkismetSettings", "Parts/AntiSpam.AkismetSettings", "spam"));
        }
        public Localizer T { get; set; }
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Spam")));
    }
}
