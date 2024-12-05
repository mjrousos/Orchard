using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
namespace Orchard.UI.PageClass {
    public interface IPageClassBuilder : IDependency {
        void AddClassNames(params object[] classNames);
    }
}
