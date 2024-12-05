using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.AntiSpam.Services {
    /// <summary>
    /// Default implementation for <see cref="ISpamFilterProvider"/> in order to have at least one result
    /// when it is resolved, event if there is no other concrete provider.
    /// </summary>
    public class NullSpamFilterProvider : ISpamFilterProvider {
        public IEnumerable<ISpamFilter> GetSpamFilters() {
            yield break;
        }
    }
}
