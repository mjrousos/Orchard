using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace Orchard.Packaging.ViewModels {
    public class PackagingAddSourceViewModel {
        [Required]
        public string Url { get; set; }
    }
}
