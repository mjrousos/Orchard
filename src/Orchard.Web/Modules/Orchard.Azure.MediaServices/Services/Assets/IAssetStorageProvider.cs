using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Azure.MediaServices.Models.Assets;
using Orchard;

namespace Orchard.Azure.MediaServices.Services.Assets {
    public interface IAssetStorageProvider : IDependency {
        void BindStorage(Asset asset);
    }
}
