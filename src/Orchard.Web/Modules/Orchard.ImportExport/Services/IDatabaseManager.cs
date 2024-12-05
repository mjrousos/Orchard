using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.ImportExport.Services {
    public interface IDatabaseManager : IDependency {
        IEnumerable<string> GetTenantDatabaseTableNames();
        void DropTenantDatabaseTables();
    }
}
