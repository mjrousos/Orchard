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
    public class VideoAssetDriver : AssetDriver<VideoAsset> {
        protected override IEnumerable<AssetDriverResult> Editor(VideoAsset asset, dynamic shapeFactory) {
            return Editor(asset, null, shapeFactory);
        }
        protected override IEnumerable<AssetDriverResult> Editor(VideoAsset asset, IUpdateModel updater, dynamic shapeFactory) {
            yield return new AssetDriverResult {
                TabTitle = T("Files"),
                EditorShape = shapeFactory.EditorTemplate(Model: asset, TemplateName: "Assets/Video.Files", Prefix: Prefix)
            };
                TabTitle = T("Preview"),
                EditorShape = shapeFactory.EditorTemplate(Model: asset, TemplateName: "Assets/Video.Preview", Prefix: Prefix)
    }
}
