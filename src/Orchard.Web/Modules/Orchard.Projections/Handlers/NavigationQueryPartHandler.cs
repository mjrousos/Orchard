using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data;
using Orchard.ContentManagement.Handlers;
using Orchard.Projections.Models;

namespace Orchard.Projections.Handlers {
    public class NavigationQueryPartHandler : ContentHandler {
        public NavigationQueryPartHandler(IRepository<NavigationQueryPartRecord> navigationQueryRepository) {
            Filters.Add(StorageFilter.For(navigationQueryRepository));
        }
    }
}
