using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.Mvc.ViewEngines {
    public class CreateThemeViewEngineParams {
        public string VirtualPath { get; set; }
    }
    public class CreateModulesViewEngineParams {
        public IEnumerable<string> VirtualPaths { get; set; }
        public IEnumerable<string> ExtensionLocations { get; set; }
    public interface IViewEngineProvider : ISingletonDependency {
        IViewEngine CreateThemeViewEngine(CreateThemeViewEngineParams parameters);
        IViewEngine CreateModulesViewEngine(CreateModulesViewEngineParams parameters);
        /// <summary>
        /// Produce a view engine configured to resolve only fully qualified {viewName} parameters
        /// </summary>
        IViewEngine CreateBareViewEngine();
}
