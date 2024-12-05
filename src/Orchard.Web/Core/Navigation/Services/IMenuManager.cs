using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Core.Navigation.Services {
    public interface IMenuManager : IDependency {
        
        /// <summary>
        /// Gets the list of Menu Item content types
        /// </summary>
        /// <returns>An IEnumerable{MenuItemDescriptor} containing the menu items content types.</returns>
        IEnumerable<MenuItemDescriptor> GetMenuItemTypes();
    }
    public class MenuItemDescriptor {
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
}
