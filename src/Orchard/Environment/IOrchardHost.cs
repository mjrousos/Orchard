using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Environment.Configuration;
using Orchard.Environment.ShellBuilders;

namespace Orchard.Environment {
    public interface IOrchardHost {
        /// <summary>
        /// Called once on startup to configure app domain, and load/apply existing shell configuration
        /// </summary>
        void Initialize();
        /// Called externally when there is explicit knowledge that the list of installed
        /// modules/extensions has changed, and they need to be reloaded.
        void ReloadExtensions();
        /// Called each time a request begins to offer a just-in-time reinitialization point
        void BeginRequest();
        /// Called each time a request ends to deterministically commit and dispose outstanding activity
        void EndRequest();
        ShellContext GetShellContext(ShellSettings shellSettings);
        /// Can be used to build an temporary self-contained instance of a shell's configured code.
        /// Services may be resolved from within this instance to configure and initialize its storage.
        IWorkContextScope CreateStandaloneEnvironment(ShellSettings shellSettings);
    }
}
