using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Routing;
using Orchard.CustomForms.Models;
using Orchard.Data;
using Orchard.ContentManagement.Handlers;

namespace Orchard.CustomForms.Handlers {
    public class CustomFormPartHandler : ContentHandler {
        public CustomFormPartHandler(IRepository<CustomFormPartRecord> customFormRepository) {
            Filters.Add(StorageFilter.For(customFormRepository));
        }
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if(context.ContentItem.ContentType != "CustomForm") {
                return;
            }
            context.Metadata.DisplayRouteValues = new RouteValueDictionary {
                {"Area", "Orchard.CustomForms"},
                {"Controller", "Item"},
                {"Action", "Create"},
                {"Id", context.ContentItem.Id}
            };
    }
}
