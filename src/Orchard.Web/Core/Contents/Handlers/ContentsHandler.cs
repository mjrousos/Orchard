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

namespace Orchard.Core.Contents.Handlers {
    public class ContentsHandler : ContentHandlerBase {
        public override void GetContentItemMetadata(GetContentItemMetadataContext context) {
            if (string.IsNullOrWhiteSpace(context.Metadata.DisplayText))
                context.Metadata.DisplayText = context.ContentItem.ContentType;
            if (context.Metadata.CreateRouteValues == null) {
                context.Metadata.CreateRouteValues = new RouteValueDictionary {
                    {"Area", "Contents"},
                    {"Controller", "Admin"},
                    {"Action", "Create"},
                    {"Id", context.ContentItem.ContentType}
                };
            }
            if (context.Metadata.EditorRouteValues == null) {
                context.Metadata.EditorRouteValues = new RouteValueDictionary {
                    {"Action", "Edit"},
                    {"Id", context.ContentItem.Id}
            if (context.Metadata.DisplayRouteValues == null) {
                context.Metadata.DisplayRouteValues = new RouteValueDictionary {
                    {"Controller", "Item"},
                    {"Action", "Display"},
            if (context.Metadata.RemoveRouteValues == null) {
                context.Metadata.RemoveRouteValues = new RouteValueDictionary {
                    {"Action", "Remove"},
        }
    }
}
