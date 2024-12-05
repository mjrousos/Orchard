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

namespace Orchard.AntiSpam.Services {
    public interface ISpamFilterProvider : IDependency {
        IEnumerable<ISpamFilter> GetSpamFilters();
    }
}
