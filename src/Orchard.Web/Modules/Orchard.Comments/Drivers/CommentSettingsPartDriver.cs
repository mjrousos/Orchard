using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Comments.Models;
using Orchard.ContentManagement.Drivers;

namespace Orchard.Comments.Drivers {
    public class CommentSettingsPartDriver : ContentPartDriver<CommentSettingsPart> {
        public CommentSettingsPartDriver() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        protected override string Prefix { get { return "CommentSettings"; } }
        protected override DriverResult Editor(CommentSettingsPart part, dynamic shapeHelper) {
            return Editor(part, null, shapeHelper);
        protected override DriverResult Editor(CommentSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            return ContentShape("Parts_Comments_SiteSettings", () => {
                    if (updater != null) {
                        updater.TryUpdateModel(part, Prefix, null, null);
                    }
                    return shapeHelper.EditorTemplate(TemplateName: "Parts.Comments.SiteSettings", Model: part, Prefix: Prefix); 
                })
                .OnGroup("comments");
    }
}
