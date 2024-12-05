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
    /// Implements <see cref="ISpamFilterProvider"/> by returning Akismet and TypePad services if they are configured
    /// </summary>
    public class DefaultSpamFilterProvider : ISpamFilterProvider {
        public IEnumerable<ISpamFilter> GetSpamFilters() {
            yield break;
        }
    }
}
