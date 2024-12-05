using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Routing;
using Orchard.ContentManagement.Handlers;
using Orchard.Core.Title.Models;
using Orchard.Data;
using Orchard.Widgets.Models;

namespace Orchard.Widgets.Handlers {
    public class WidgetPartHandler : ContentHandler {
        public WidgetPartHandler(IRepository<WidgetPartRecord> widgetsRepository) {
            Filters.Add(StorageFilter.For(widgetsRepository));
            OnInitializing<WidgetPart>((context, part) => part.RenderTitle = true);
        }
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var widget = context.ContentItem.As<WidgetPart>();
            if (widget == null)
                return;
            context.Metadata.DisplayText = widget.Title;
            // create needs to go through the add widget flow (index -> [select layer -> ] add [widget type] to layer)
            context.Metadata.CreateRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.Widgets"},
                {"Controller", "Admin"},
                {"Action", "Index"}
            };
            context.Metadata.EditorRouteValues = new RouteValueDictionary {
                {"Action", "EditWidget"},
                {"Id", context.ContentItem.Id}
            // remove goes through edit widget...
            context.Metadata.RemoveRouteValues = new RouteValueDictionary {
    }
}
