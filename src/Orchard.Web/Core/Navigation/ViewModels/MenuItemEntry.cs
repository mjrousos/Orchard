using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.UI.Navigation;

namespace Orchard.Core.Navigation.ViewModels {
    public class MenuItemEntry {
        public int MenuItemId { get; set; }
        public bool IsMenuItem { get; set; }
        
        public string Text { get; set; }
        public string Url { get; set; }
        public string Position { get; set; }
        public ContentItem ContentItem { get; set; }
    }
}
