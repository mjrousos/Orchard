using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.IO;

namespace Orchard.Commands {
    public class CommandParameters {
        public IEnumerable<string> Arguments { get; set; }
        public IDictionary<string, string> Switches { get; set; }
        public TextReader Input { get; set; }
        public TextWriter Output { get; set; }
    }
}
