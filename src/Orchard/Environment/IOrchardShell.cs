using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Tasks;

namespace Orchard.Environment {
    public interface IOrchardShell {
        void Activate();
        void Terminate();
        ISweepGenerator Sweep { get; }
    }
}
