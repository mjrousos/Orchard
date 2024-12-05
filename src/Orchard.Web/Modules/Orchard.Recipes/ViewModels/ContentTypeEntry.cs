using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Recipes.ViewModels {
    public class ContentTypeEntry {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool ExportSchema { get; set; }
        public bool ExportData { get; set; }
    }
}
