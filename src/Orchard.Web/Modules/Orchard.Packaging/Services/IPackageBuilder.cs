using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.IO;
using Orchard.Environment.Extensions.Models;

namespace Orchard.Packaging.Services {
    public interface IPackageBuilder : IDependency {
        Stream BuildPackage(ExtensionDescriptor extensionDescriptor);
    }
}
