using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement.Handlers;
using Orchard.Core.Navigation.Models;

namespace Orchard.Core.Navigation.Handlers {
    public class MenuWidgetPartHandler : ContentHandler {
        public MenuWidgetPartHandler() {
            OnInitializing<MenuWidgetPart>((context, part) => { part.StartLevel = 1; });
        }
    }
}
