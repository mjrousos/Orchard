using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Layouts.Framework.Elements {
    public class CategoryDescriptor {
        public CategoryDescriptor() {
            Elements = new List<ElementDescriptor>();
        }
        public CategoryDescriptor(string name, LocalizedString displayName, LocalizedString description, int position) : this() {
            Name = name;
            DisplayName = displayName;
            Description = description;
            Position = position;
        public string Name { get; set; }
        public LocalizedString DisplayName { get; set; }
        public LocalizedString Description { get; set; }
        public int Position { get; set; }
        public IList<ElementDescriptor> Elements { get; set; }
    }
}
