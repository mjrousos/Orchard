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
using System.Web;
using Orchard.Data.Providers;

namespace Orchard.Autoroute.Services {
    public class AutorouteNoLockTableProvider : INoLockTableProvider {
        public IEnumerable<string> GetTableNames() {
            return new string[] { "Orchard_Autoroute_AutoroutePartRecord" };
        }
    }
}
