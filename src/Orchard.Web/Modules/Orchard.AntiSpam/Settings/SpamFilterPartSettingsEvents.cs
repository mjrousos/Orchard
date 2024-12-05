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

namespace Orchard.AntiSpam.Settings {
    public class SpamFilterPartSettingsEvents : ContentDefinitionEditorEventsBase {
        public Localizer T { get; set; }
        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition) {
            if (definition.PartDefinition.Name != "SpamFilterPart")
                yield break;
            var settings = definition.Settings.GetModel<SpamFilterPartSettings>();
            yield return DefinitionTemplate(settings);
        }
        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updateModel) {
            if (builder.Name != "SpamFilterPart")
            var settings = new SpamFilterPartSettings {
            };
            if (updateModel.TryUpdateModel(settings, "SpamFilterPartSettings", null, null)) {
                builder.WithSetting("SpamFilterPartSettings.Action", settings.Action.ToString());
                builder.WithSetting("SpamFilterPartSettings.DeleteSpam", settings.DeleteSpam.ToString(CultureInfo.InvariantCulture));
                builder.WithSetting("SpamFilterPartSettings.UrlPattern", settings.UrlPattern);
                builder.WithSetting("SpamFilterPartSettings.PermalinkPattern", settings.PermalinkPattern);
                builder.WithSetting("SpamFilterPartSettings.CommentAuthorPattern", settings.CommentAuthorPattern);
                builder.WithSetting("SpamFilterPartSettings.CommentAuthorUrlPattern", settings.CommentAuthorUrlPattern);
                builder.WithSetting("SpamFilterPartSettings.CommentAuthorEmailPattern", settings.CommentAuthorEmailPattern);
                builder.WithSetting("SpamFilterPartSettings.CommentContentPattern", settings.CommentContentPattern);
            }
    }
}
