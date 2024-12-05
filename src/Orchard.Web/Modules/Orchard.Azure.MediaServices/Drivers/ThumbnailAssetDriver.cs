using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Azure.MediaServices.Infrastructure.Assets;
using Orchard.Azure.MediaServices.Models.Assets;

namespace Orchard.Azure.MediaServices.Drivers {
    public class ThumbnailAssetDriver : AssetDriver<ThumbnailAsset> {
        protected override IEnumerable<AssetDriverResult> Editor(ThumbnailAsset asset, dynamic shapeFactory) {
            return Editor(asset, null, shapeFactory);
        }
        protected override IEnumerable<AssetDriverResult> Editor(ThumbnailAsset asset, IUpdateModel updater, dynamic shapeFactory) {
            yield return new AssetDriverResult {
                TabTitle = T("Thumbnail"),
                EditorShape = shapeFactory.EditorTemplate(Model: asset, TemplateName: "Assets/Thumbnail.Preview", Prefix: Prefix)
            };
    }
}
