using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Caching;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Widgets.Models;

namespace Orchard.Widgets.Handlers {
    public class LayerPartHandler : ContentHandler {
        private readonly ISignals _signals;
        public LayerPartHandler(
            IRepository<LayerPartRecord> layersRepository,
            ISignals signals) {
            Filters.Add(StorageFilter.For(layersRepository));
            _signals = signals;
            
            // Evict cached content when updated, removed or destroyed.
            OnUpdated<LayerPart>(
                (context, part) => Invalidate());
            OnImported<LayerPart>(
            OnPublished<LayerPart>(
            OnRemoved<LayerPart>(
            OnDestroyed<LayerPart>(
        }
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var part = context.ContentItem.As<LayerPart>();
            if (part != null) {
                 context.Metadata.Identity.Add("Layer.LayerName", part.Name);
            }
        private void Invalidate() {
            _signals.Trigger(LayerPart.AllLayersCacheEvictSignal);
    }
}
