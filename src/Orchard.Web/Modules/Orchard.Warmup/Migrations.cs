using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration;

namespace Orchard.Warmup {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            
            return 1;
        }
    }
}
