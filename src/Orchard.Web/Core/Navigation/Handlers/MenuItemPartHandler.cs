using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Core.Navigation.Models;
using Orchard.ContentManagement.Handlers;

namespace Orchard.Core.Navigation.Handlers {
    public class MenuItemPartHandler : ContentHandler {
        public MenuItemPartHandler() {
            Filters.Add(new ActivatingFilter<MenuItemPart>("MenuItem"));
        }
    }
}
