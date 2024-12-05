using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Handlers;
using Orchard.DesignerTools.Models;
using Orchard.Utility.Extensions;

namespace Orchard.DesignerTools.Handlers {
    public class ShapeTracingSiteSettingsPartHandler : ContentHandler {
        public Localizer T { get; set; }
        public ShapeTracingSiteSettingsPartHandler() {
            T = NullLocalizer.Instance;
            Filters.Add(new ActivatingFilter<ShapeTracingSiteSettingsPart>("Site"));
            Filters.Add(new TemplateFilterForPart<ShapeTracingSiteSettingsPart>("ShapeTracingSiteSettings", "Parts/ShapeTracing.ShapeTracingSiteSettings", "ShapeTracing"));
            OnInitializing<ShapeTracingSiteSettingsPart>(AssignDefaultValues);
        }
        private void AssignDefaultValues(InitializingContentContext context, ShapeTracingSiteSettingsPart part) {
            part.IsShapeTracingActive = true;
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site")
                return;
            base.GetItemMetadata(context);
            var groupInfo = new GroupInfo(T("Shape Tracing"));
            context.Metadata.EditorGroupInfo.Add(groupInfo);
    }
}
