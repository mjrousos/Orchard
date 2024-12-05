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
using Orchard.Users.Models;

namespace Orchard.Users.Handlers {
    public class UserSuspensionSettingsPartHandler : ContentHandler {
        public UserSuspensionSettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<UserSuspensionSettingsPart>("Site"));
            Filters.Add(
                new TemplateFilterForPart<UserSuspensionSettingsPart>("SuspensionSettings", "Parts/Users.SuspensionSettings", "users")
                    .Position("6"));
        }
        public Localizer T { get; set; }
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T("Users")));
    }
}
