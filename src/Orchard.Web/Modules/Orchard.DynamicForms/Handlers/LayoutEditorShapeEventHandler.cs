using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DisplayManagement.Descriptors;
using Orchard.Environment;
using Orchard.UI.Resources;

namespace Orchard.DynamicForms.Handlers {
    public class LayoutEditorShapeEventHandler : IShapeTableProvider {
        private readonly Work<IResourceManager> _resourceManager;
        public LayoutEditorShapeEventHandler(Work<IResourceManager> resourceManager) {
            _resourceManager = resourceManager;
        }
        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("EditorTemplate").OnDisplaying(context => {
                if (context.Shape.TemplateName != "Parts.Layout")
                    return;
                _resourceManager.Value.Require("stylesheet", "DynamicForms.FormElements");
                _resourceManager.Value.Require("script", "DynamicForms.FormElements");
            });
    }
}
