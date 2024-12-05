using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.Security {
    /// <summary>
    /// Interface provided by the "User" model. 
    /// </summary>
    public interface IUser : IContent {
        string UserName { get; }
        string Email { get; }
    }
}
