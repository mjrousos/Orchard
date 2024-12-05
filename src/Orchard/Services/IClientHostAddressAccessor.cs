using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.Services {
    /// <summary>
    /// Provides access to the user host address.
    /// </summary>
    public interface IClientHostAddressAccessor : IDependency {
        string GetClientAddress();
    }
}
