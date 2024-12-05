using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.ImportExport.ViewModels {
    public class ExportStepViewModel {
        public string Name { get; set; }
        public LocalizedString DisplayName { get; set; }
        public LocalizedString Description { get; set; }
        public bool IsSelected { get; set; }
        public dynamic Editor { get; set; }
        public bool IsVisible { get; set; }
    }
}
