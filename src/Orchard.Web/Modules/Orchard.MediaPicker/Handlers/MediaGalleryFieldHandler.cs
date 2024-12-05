using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.ContentManagement.Handlers;
using Orchard.ContentManagement.MetaData;
using Orchard.MediaPicker.Fields;

namespace Orchard.MediaPicker.Handlers {
    public class MediaGalleryFieldHandler : ContentHandler {
        private readonly IJsonConverter _jsonConverter;
        private readonly IContentDefinitionManager _contentDefinitionManager;
        public MediaGalleryFieldHandler(
            IJsonConverter jsonConverter,
            IContentDefinitionManager contentDefinitionManager) {
            
            _jsonConverter = jsonConverter;
            _contentDefinitionManager = contentDefinitionManager;
        }
        protected override void Loading(LoadContentContext context) {
            base.Loading(context);
            var fields = context.ContentItem.Parts.SelectMany(x => x.Fields.Where(f => f.FieldDefinition.Name == typeof (MediaGalleryField).Name)).Cast<MediaGalleryField>();
            // define lazy initializer for MediaGalleryField.Items
            var contentTypeDefinition = _contentDefinitionManager.GetTypeDefinition(context.ContentType);
            if (contentTypeDefinition == null) {
                return;
            }
            foreach (var field in fields) {
                var localField = field;
                field._mediaGalleryItems.Loader(() => _jsonConverter.Deserialize<MediaGalleryItem[]>(localField.SelectedItems ?? "[]") ?? new MediaGalleryItem[0]);
    }
}
