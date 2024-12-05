using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Orchard.Environment.Extensions.Models;
using Orchard.Packaging.Models;

namespace Orchard.Packaging.ViewModels {
    public class PackagingHarvestViewModel {
        public IEnumerable<PackagingSource> Sources { get; set; }
        public IEnumerable<ExtensionDescriptor> Extensions { get; set; }
        [Required]
        public string ExtensionName { get; set; }
        public string FeedUrl { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
