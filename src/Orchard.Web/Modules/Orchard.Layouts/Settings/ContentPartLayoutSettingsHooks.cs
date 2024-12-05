using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;
using Orchard.Layouts.Helpers;

namespace Orchard.Layouts.Settings {
    public class ContentPartLayoutSettingsHooks : ContentDefinitionEditorEventsBase {
        public override IEnumerable<TemplateViewModel> PartEditor(ContentPartDefinition definition) {
            var model = definition.Settings.GetModel<ContentPartLayoutSettings>();
            yield return DefinitionTemplate(model);
        }
        public override IEnumerable<TemplateViewModel> PartEditorUpdate(ContentPartDefinitionBuilder builder, IUpdateModel updateModel) {
            var model = new ContentPartLayoutSettings();
            updateModel.TryUpdateModel(model, "ContentPartLayoutSettings", null, null);
            builder.Placeable(model.Placeable);
    }
}
