using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Web.Routing;

namespace Orchard.Themes {
    public class ThemeSelectorResult {
        public int Priority { get; set; }
        public string ThemeName { get; set; }
    }
    public interface IThemeSelector : IDependency {
        ThemeSelectorResult GetTheme(RequestContext context);
}
