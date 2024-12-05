using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.OutputCache.Models;

namespace Orchard.OutputCache.ViewModels {
    public class StatisticsViewModel {
        public IEnumerable<CacheItem> CacheItems { get; set; }
        public dynamic Pager { get; set; }
    }
}
