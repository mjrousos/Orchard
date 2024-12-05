using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.IO;

namespace Orchard.Packaging.Models {
    public class PackageData {
        public string ExtensionType { get; set; }
        public string ExtensionName { get; set; }
        public string ExtensionVersion { get; set; }
        public Stream PackageStream { get; set; }
    }
}
