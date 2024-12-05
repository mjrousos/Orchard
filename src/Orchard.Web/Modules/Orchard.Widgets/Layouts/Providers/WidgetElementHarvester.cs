using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.Core.Contents.Settings;
using Orchard.Environment;
using Orchard.Environment.Extensions;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Framework.Harvesters;
using Orchard.Layouts.Helpers;
using Orchard.Layouts.Models;
using Orchard.Security;
using Orchard.Widgets.Layouts.Elements;
using Orchard.Widgets.ViewModels;

namespace Orchard.Widgets.Layouts.Providers {
    [OrchardFeature("Orchard.Widgets.Elements")]
    public class WidgetElementHarvester : Component, IElementHarvester {
        private readonly Work<IContentManager> _contentManager;
        private readonly IAuthorizer _authorizer;

        public WidgetElementHarvester(Work<IContentManager> contentManager, IAuthorizer authorizer) {
            _contentManager = contentManager;
            _authorizer = authorizer;
        }

        public IEnumerable<ElementDescriptor> HarvestElements(HarvestElementsContext context) {
            var contentTypeDefinitions = GetWidgetContentTypeDefinitions();
            return contentTypeDefinitions.Select(contentTypeDefinition => {
                var settings = contentTypeDefinition.Settings;
                var description = settings.ContainsKey("Description") ? settings["Description"] : contentTypeDefinition.DisplayName;
                return new ElementDescriptor(typeof(Widget), contentTypeDefinition.Name, T.Encode(contentTypeDefinition.DisplayName), T.Encode(description), category: "Widgets") {
                    Displaying = Displaying,
                    Editor = Editor,
                    UpdateEditor = UpdateEditor,
                    ToolboxIcon = "\uf1b2",
                    EnableEditorDialog = true,
                    Removing = RemoveContentItem,
                    Exporting = ExportElement,
                    Importing = ImportElement,
                    StateBag = new Dictionary<string, object> {
                        { "ContentTypeName", contentTypeDefinition.Name }
                    },
                    LayoutSaving = LayoutSaving
                };
            });
        }

        protected void LayoutSaving(ElementSavingContext context) {
            var element = (Widget)context.Element;
            if (element == null) {
                return;
            }
            var widgetId = element.WidgetId;
            var widget = _contentManager.Value.Get(widgetId.Value, VersionOptions.Latest);
            if (widget == null) {
                return;
            }
            var commonPart = widget.As<ICommonPart>();
            if (commonPart != null) {
                commonPart.Container = context.Content;
            }
        }

        protected void Displaying(ElementDisplayingContext context) {
            var element = (Widget)context.Element;
            var widgetId = element.WidgetId;
            var contentTypeName = (string)context.Element.Descriptor.StateBag["ContentTypeName"];
            var versionOptions = context.DisplayType == "Design" ? VersionOptions.Latest : VersionOptions.Published;
            var widget = widgetId != null
                ? _contentManager.Value.Get(widgetId.Value, versionOptions)
                : _contentManager.Value.New(contentTypeName);

            if (!_authorizer.Authorize(Core.Contents.Permissions.ViewContent, widget)) {
                return;
            }

            var widgetShape = widget != null ? _contentManager.Value.BuildDisplay(widget, context.DisplayType) : default(dynamic);
            context.ElementShape.Widget = widget;
            context.ElementShape.WidgetShape = widgetShape;
        }

        protected void Editor(ElementEditorContext context) {
            UpdateEditor(context);
        }

        protected void UpdateEditor(ElementEditorContext context) {
            var element = (Widget)context.Element;
            var elementViewModel = new WidgetElementViewModel {
                WidgetId = element.WidgetId
            };

            if (context.Updater != null) {
                context.Updater.TryUpdateModel(elementViewModel, context.Prefix, null, null);
            }

            var widgetId = elementViewModel.WidgetId;
            var widget = widgetId != null
                ? _contentManager.Value.Get(widgetId.Value, VersionOptions.Latest)
                : _contentManager.Value.New((string)context.Element.Descriptor.StateBag["ContentTypeName"]);

            dynamic contentEditorShape;
            if (widget.Id == 0) {
                _contentManager.Value.Create(widget, VersionOptions.Draft);
            }
            else {
                var isDraftable = widget.TypeDefinition.Settings.GetModel<ContentTypeSettings>().Draftable;
                var versionOptions = isDraftable ? VersionOptions.DraftRequired : VersionOptions.Latest;
                widget = _contentManager.Value.Get(widget.Id, versionOptions);
            }

            element.WidgetId = widget.Id;

            var commonPart = widget.As<ICommonPart>();
            if (commonPart != null) {
                commonPart.Container = context.Content;
            }

            widget.IsPlaceableContent(true);
            contentEditorShape = context.Updater != null
                ? _contentManager.Value.UpdateEditor(widget, context.Updater)
                : _contentManager.Value.BuildEditor(widget);

            var elementEditorShape = context.ShapeFactory.EditorTemplate(TemplateName: "Elements.Widget", Model: elementViewModel, Prefix: context.Prefix);
            elementEditorShape.Metadata.Position = "Properties:0";
            contentEditorShape.Metadata.Position = "Properties:0";
            context.EditorResult.Add(elementEditorShape);
            context.EditorResult.Add(contentEditorShape);
        }

        protected void RemoveContentItem(ElementRemovingContext context) {
            var element = (Widget)context.Element;
            var widgetId = element.WidgetId;

            if (!widgetId.HasValue)
                return;

            var widgetElements =
                from e in context.Elements.Flatten()
                let p = e as Widget
                where p != null && p.WidgetId == widgetId
                select p;

            if (widgetElements.Any())
                return;

            var contentItem = _contentManager.Value.Get(widgetId.Value, VersionOptions.Latest);
            if (contentItem != null)
                _contentManager.Value.Remove(contentItem);
        }

        protected void ExportElement(ExportElementContext context) {
            var element = (Widget)context.Element;
            var widgetId = element.WidgetId;
            var widget = widgetId != null ? _contentManager.Value.Get(widgetId.Value, VersionOptions.Latest) : default(ContentItem);
            var widgetIdentity = widget != null ? _contentManager.Value.GetItemMetadata(widget).Identity.ToString() : default(string);

            if (widgetIdentity != null)
                context.ExportableData["WidgetId"] = widgetIdentity;
        }

        protected void ImportElement(ImportElementContext context) {
            var element = (Widget)context.Element;
            var widgetIdentity = context.ExportableData.Get("WidgetId");

            if (String.IsNullOrWhiteSpace(widgetIdentity))
                return;

            var widget = context.Session.GetItemFromSession(widgetIdentity);

            if (widget == null)
                return;

            var cp = widget.As<ICommonPart>();
            if (cp != null) {
                var lp = cp.Container.As<LayoutPart>();
                if (lp != null && lp.Id != context.Layout.Id) {
                    widget = _contentManager.Value.Clone(widget);
                }
            }

            element.WidgetId = widget != null ? widget.Id : default(int?);
        }

        private IEnumerable<ContentTypeDefinition> GetWidgetContentTypeDefinitions() {
            var contentTypeDefinitionsQuery =
                from contentTypeDefinition in _contentManager.Value.GetContentTypeDefinitions()
                let stereotype = contentTypeDefinition.Settings.ContainsKey("Stereotype") ? contentTypeDefinition.Settings["Stereotype"] : default(string)
                where stereotype == "Widget"
                select contentTypeDefinition;

            return contentTypeDefinitionsQuery.ToList();
        }
    }
}
