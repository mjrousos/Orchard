using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Globalization;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace Orchard.Comments.Settings {
    public class CommentsPartSettingsEvents : ContentDefinitionEditorEventsBase {
        public Localizer T { get; set; }
        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition) {
            if (definition.PartDefinition.Name != "CommentsPart")
                yield break;
            var settings = definition.Settings.GetModel<CommentsPartSettings>();
            yield return DefinitionTemplate(settings);
        }
        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updateModel) {
            if (builder.Name != "CommentsPart")
            var settings = new CommentsPartSettings {
            };
            if (updateModel.TryUpdateModel(settings, "CommentsPartSettings", null, null)) {
                builder.WithSetting("CommentsPartSettings.DefaultThreadedComments", settings.DefaultThreadedComments.ToString(CultureInfo.InvariantCulture));
                builder.WithSetting("CommentsPartSettings.MustBeAuthenticated", settings.MustBeAuthenticated.ToString(CultureInfo.InvariantCulture));
            }
    }
}
