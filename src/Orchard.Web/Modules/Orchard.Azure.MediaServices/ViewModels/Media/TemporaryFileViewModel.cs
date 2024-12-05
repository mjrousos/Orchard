using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Azure.MediaServices.ViewModels.Media {
    public class TemporaryFileViewModel {
        public string OriginalFileName { get; set; }
        public string TemporaryFileName { get; set; }
        public long FileSize { get; set; }
    }
}
