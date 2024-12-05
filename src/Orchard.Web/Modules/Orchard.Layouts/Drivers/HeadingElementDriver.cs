using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Elements;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Helpers;
using Orchard.Layouts.ViewModels;

namespace Orchard.Layouts.Drivers {
    public class HeadingElementDriver : ElementDriver<Heading> {
        private readonly IHtmlFilterProcessor _htmlFilterProcessor;
        public HeadingElementDriver(IHtmlFilterProcessor htmlFilterProcessor) {
            _htmlFilterProcessor = htmlFilterProcessor;
        }
        protected override EditorResult OnBuildEditor(Heading element, ElementEditorContext context) {
            var viewModel = new HeadingEditorViewModel {
                Text = element.Content,
                Level = element.Level
            };
            var editor = context.ShapeFactory.EditorTemplate(TemplateName: "Elements.Heading", Model: viewModel);
            if (context.Updater != null) {
                context.Updater.TryUpdateModel(viewModel, context.Prefix, null, null);
                element.Content = viewModel.Text;
                element.Level = viewModel.Level;
            }
            
            return Editor(context, editor);
        protected override void OnDisplaying(Heading element, ElementDisplayingContext context) {
            context.ElementShape.ProcessedContent = _htmlFilterProcessor.ProcessFilters(element.Content, new HtmlFilterContext { Flavor = "html", Data = context.GetTokenData() });
            context.ElementShape.Level = element.Level;
    }
}
