using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.IO;
using Orchard.Host;

namespace Orchard.HostContext {
    public class CommandHostContext {
        public CommandReturnCodes StartSessionResult { get; set; }
        public CommandReturnCodes RetryResult { get; set; }
        public OrchardParameters Arguments { get; set; }
        public DirectoryInfo OrchardDirectory { get; set; }
        public bool DisplayUsageHelp { get; set; }
        public CommandHost CommandHost { get; set; }
        public Logger Logger { get; set; }
    }
}
