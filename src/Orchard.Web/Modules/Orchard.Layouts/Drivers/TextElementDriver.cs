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

namespace Orchard.Layouts.Drivers
{
    public class TextElementDriver : ElementDriver<Text> {
        private readonly IHtmlFilterProcessor _htmlFilterProcessor;
        public TextElementDriver(IHtmlFilterProcessor htmlFilterProcessor) {
            _htmlFilterProcessor = htmlFilterProcessor;
        }
        protected override EditorResult OnBuildEditor(Text element, ElementEditorContext context) {
            var viewModel = new TextEditorViewModel {
                Content = element.Content
            };
            var editor = context.ShapeFactory.EditorTemplate(TemplateName: "Elements.Text", Model: viewModel);
            if (context.Updater != null) {
                context.Updater.TryUpdateModel(viewModel, context.Prefix, null, null);
                element.Content = viewModel.Content;
            }
            
            return Editor(context, editor);
        protected override void OnDisplaying(Text element, ElementDisplayingContext context) {
            context.ElementShape.ProcessedContent = _htmlFilterProcessor.ProcessFilters(element.Content, new HtmlFilterContext { Flavor = "textarea", Data = context.GetTokenData() });
    }
}
