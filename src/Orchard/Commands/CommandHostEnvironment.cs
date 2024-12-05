using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Reflection;
using Orchard.Environment;

namespace Orchard.Commands {
    internal class CommandHostEnvironment : HostEnvironment {
        public CommandHostEnvironment() {
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public override void RestartAppDomain() {
            throw new OrchardCommandHostRetryException(T("A change of configuration requires the session to be restarted."));
    }
}
