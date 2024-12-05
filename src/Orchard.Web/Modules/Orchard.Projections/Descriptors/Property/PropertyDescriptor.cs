using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Projections.Descriptors.Property {
    public class PropertyDescriptor {
        public string Category { get; set; }
        public string Type { get; set; }
        public LocalizedString Name { get; set; }
        public LocalizedString Description { get; set; }
        public string Form { get; set; }
        public Func<PropertyContext, LocalizedString> Display { get; set; }
        public Func<PropertyContext, ContentItem, dynamic> Property { get; set; }
    }
}
