using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace Orchard.Core.Common.Settings {
    public class BodyPartSettings {
        public const string FlavorDefaultDefault = "html";
        private string _flavorDefault;
        [DataType("Flavor")]
        public string FlavorDefault {
            get { return !string.IsNullOrWhiteSpace(_flavorDefault)
                           ? _flavorDefault
                           : FlavorDefaultDefault; }
            set { _flavorDefault = value; }
        }
    }
    public class BodyTypePartSettings {
        public string Flavor { get; set; }
    public class BodySettingsHooks : ContentDefinitionEditorEventsBase {
        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition) {
            if (definition.PartDefinition.Name != "BodyPart")
                yield break;
            var model = definition.Settings.GetModel<BodyTypePartSettings>();
            if (string.IsNullOrWhiteSpace(model.Flavor)) {
                var partModel = definition.PartDefinition.Settings.GetModel<BodyPartSettings>();
                model.Flavor = partModel.FlavorDefault;
            }
            yield return DefinitionTemplate(model);
        public override IEnumerable<TemplateViewModel> PartEditor(ContentPartDefinition definition) {
            if (definition.Name != "BodyPart")
            var model = definition.Settings.GetModel<BodyPartSettings>();
        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updateModel) {
            if (builder.Name != "BodyPart")
            var model = new BodyTypePartSettings();
            updateModel.TryUpdateModel(model, "BodyTypePartSettings", null, null);
            builder.WithSetting("BodyTypePartSettings.Flavor", !string.IsNullOrWhiteSpace(model.Flavor) ? model.Flavor : null);
        public override IEnumerable<TemplateViewModel> PartEditorUpdate(ContentPartDefinitionBuilder builder, IUpdateModel updateModel) {
            var model = new BodyPartSettings();
            updateModel.TryUpdateModel(model, "BodyPartSettings", null, null);
            builder.WithSetting("BodyPartSettings.FlavorDefault", !string.IsNullOrWhiteSpace(model.FlavorDefault) ? model.FlavorDefault : null);
}
