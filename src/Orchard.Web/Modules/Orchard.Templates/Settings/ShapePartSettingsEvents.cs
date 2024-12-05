using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;
using Orchard.Templates.Services;
using Orchard.Templates.ViewModels;

namespace Orchard.Templates.Settings {
    public class ShapePartSettingsEvents : ContentDefinitionEditorEventsBase {
        private readonly IEnumerable<ITemplateProcessor> _processors;
        public ShapePartSettingsEvents(IEnumerable<ITemplateProcessor> processors) {
            _processors = processors;
        }
        public override IEnumerable<TemplateViewModel> TypePartEditor(ContentTypePartDefinition definition) {
            if (definition.PartDefinition.Name != "ShapePart")
                yield break;
            var settings = definition.Settings.GetModel<ShapePartSettings>();
            var model = new ShapePartSettingsViewModel {
                Processor = settings.Processor,
                AvailableProcessors = _processors.ToArray()
            };
            yield return DefinitionTemplate(model);
        public override IEnumerable<TemplateViewModel> TypePartEditorUpdate(ContentTypePartDefinitionBuilder builder, IUpdateModel updateModel) {
            if (builder.Name != "ShapePart")
            updateModel.TryUpdateModel(model, "ShapePartSettingsViewModel", new[] { "Processor" }, null);
            builder.WithSetting("ShapePartSettings.Processor", model.Processor);
    }
}
