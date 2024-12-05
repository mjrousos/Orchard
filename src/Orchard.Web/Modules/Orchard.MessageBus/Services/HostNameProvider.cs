using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.MessageBus.Services {
    public class HostNameProvider : IHostNameProvider {
        public string GetHostName() {
            // use the current host and the process id as two servers could run on the same machine
            return System.Net.Dns.GetHostName() + ":" + System.Diagnostics.Process.GetCurrentProcess().Id;
        }
    }
}
