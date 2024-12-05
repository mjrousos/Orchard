using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.ImportExport.ViewModels {
    public class CustomStepEntry {
        public string CustomStep { get; set; }
        public bool IsChecked { get; set; }
    }
}
