using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Localization;

namespace Orchard.Layouts.Framework.Elements {
    public class Category {
        public Category() {}
        public Category(string name, LocalizedString displayName, LocalizedString description = null, int position = 0) {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Position = position;
        }
        public string Name { get; set; }
        public LocalizedString DisplayName { get; set; }
        public LocalizedString Description { get; set; }
        public int Position { get; set; }
    }
}
