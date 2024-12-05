using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;

namespace Orchard.Layouts.Framework.Drivers {
    public interface IContentImportSession {
        ContentItem GetItemFromSession(string id);
    }
}
