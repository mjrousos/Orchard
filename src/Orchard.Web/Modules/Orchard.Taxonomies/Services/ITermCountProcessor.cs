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
using Orchard.Events;

namespace Orchard.Taxonomies.Services {
    public interface ITermCountProcessor : IEventHandler {
        void Process(IEnumerable<int> termPartRecordIds);
    }
}
