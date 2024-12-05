using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Data.Providers;

namespace Orchard.Indexing.Services {
    public class IndexingNoLockTableProvider : INoLockTableProvider {
        public IEnumerable<string> GetTableNames() {
            return new string[] { "Orchard_Indexing_IndexingTaskRecord" };
        }
    }
}
