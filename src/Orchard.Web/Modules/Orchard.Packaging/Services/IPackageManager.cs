using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using NuGet;
using Orchard.Environment.Extensions.Models;
using Orchard.Packaging.Models;

namespace Orchard.Packaging.Services {
    public interface IPackageManager : IDependency {
        PackageData Harvest(string extensionName);
        PackageInfo Install(IPackage package, string location, string applicationPath);
        PackageInfo Install(string packageId, string version, string location, string applicationPath);
        void Uninstall(string packageId, string applicationPath);
    }
}
