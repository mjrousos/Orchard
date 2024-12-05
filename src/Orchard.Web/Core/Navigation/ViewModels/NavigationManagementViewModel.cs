using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.Core.Navigation.Services;

namespace Orchard.Core.Navigation.ViewModels {
    public class NavigationManagementViewModel  {
        public NavigationManagementViewModel() {
            MenuItemEntries = Enumerable.Empty<MenuItemEntry>().ToList();
        }
        public MenuItemEntry NewMenuItem { get; set; }
        public IList<MenuItemEntry> MenuItemEntries { get; set; }
        public IEnumerable<MenuItemDescriptor> MenuItemDescriptors { get; set; }
        public IEnumerable<IContent> Menus { get; set; }
        public IContent CurrentMenu { get; set; }
    }
}
