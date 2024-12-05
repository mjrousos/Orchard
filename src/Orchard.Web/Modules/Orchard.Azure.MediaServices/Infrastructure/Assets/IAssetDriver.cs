using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Azure.MediaServices.Models.Assets;
using Orchard;

namespace Orchard.Azure.MediaServices.Infrastructure.Assets {
    public interface IAssetDriver : IDependency {
        IEnumerable<AssetDriverResult> BuildEditor(Asset asset, dynamic shapeFactory);
        IEnumerable<AssetDriverResult> UpdateEditor(Asset asset, IUpdateModel updater, dynamic shapeFactory);
    }
}
