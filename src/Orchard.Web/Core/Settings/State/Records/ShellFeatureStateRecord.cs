using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Environment.State.Models;

namespace Orchard.Core.Settings.State.Records {
    public class ShellFeatureStateRecord {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ShellFeatureState.State InstallState { get; set; }
        public virtual ShellFeatureState.State EnableState { get; set; }
    }
}
