using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;

namespace Orchard.Parameters {
    public class CommandParameters {
        public IList<string> Arguments { get; set; }
        public IDictionary<string, string> Switches { get; set; }
    }
}
