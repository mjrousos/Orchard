using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.Handlers;
using Orchard.Core.Navigation.Models;
using Orchard.Data;

namespace Orchard.Core.Navigation.Handlers {
    public class AdminMenuPartHandler : ContentHandler {
        public AdminMenuPartHandler(IRepository<AdminMenuPartRecord> menuPartRepository) {
            Filters.Add(StorageFilter.For(menuPartRepository));
            OnInitializing<AdminMenuPart>((ctx, x) => {
                                      x.OnAdminMenu = false;
                                      x.AdminMenuText = String.Empty;
                                  });
        }
    }
}
