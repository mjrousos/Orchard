﻿using Orchard.Environment.Extensions;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Helpers;
using Orchard.Layouts.ViewModels;
using Orchard.Services;
using MarkdownElement = Orchard.Layouts.Elements.Markdown;

namespace Orchard.Layouts.Drivers
{
    [OrchardFeature("Orchard.Layouts.Markdown")]
    public class MarkdownElementDriver : ElementDriver<MarkdownElement> {
        private readonly IHtmlFilterProcessor _htmlFilterProcessor;
        public MarkdownElementDriver(IHtmlFilterProcessor htmlFilterProcessor) {
            _htmlFilterProcessor = htmlFilterProcessor;
        }

        protected override EditorResult OnBuildEditor(MarkdownElement element, ElementEditorContext context) {
            var viewModel = new MarkdownEditorViewModel {
                Text = element.Content
            };
            var editor = context.ShapeFactory.EditorTemplate(TemplateName: "Elements.Markdown", Model: viewModel);

            if (context.Updater != null) {
                context.Updater.TryUpdateModel(viewModel, context.Prefix, null, null);
                element.Content = viewModel.Text;
            }
            
            return Editor(context, editor);
        }

        protected override void OnDisplaying(MarkdownElement element, ElementDisplayingContext context) {
            context.ElementShape.ProcessedContent = _htmlFilterProcessor.ProcessFilters(element.Content, new HtmlFilterContext { Flavor = "markdown", Data = context.GetTokenData() });
        }
    }
}