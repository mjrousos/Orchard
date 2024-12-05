using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Tasks;

namespace Orchard.Commands {
    /// <summary>
    /// Command line specific "no-op" background service implementation.
    /// Note that we make this class "internal" so that it's not auto-registered
    /// by the Orchard Framework (it is registered explicitly by the command
    /// line host).
    /// </summary>
    internal class CommandBackgroundService : IBackgroundService {
        public void Sweep() {
            // Don't run any background service in command line
        }
    }
}
