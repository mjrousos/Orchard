using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;

namespace Orchard.Projections.Descriptors.Property {
    public class DescribePropertyFor {
        private readonly string _category;
        public DescribePropertyFor(string category, LocalizedString name, LocalizedString description) {
            Types = new List<PropertyDescriptor>();
            _category = category;
            Name = name;
            Description = description;
        }
        public LocalizedString Name { get; private set; }
        public LocalizedString Description { get; private set; }
        public List<PropertyDescriptor> Types { get; private set; }
        public DescribePropertyFor Element(string type, LocalizedString name, LocalizedString description, Func<PropertyContext, LocalizedString> display, Func<PropertyContext, ContentItem, dynamic> property, string form = null) {
            Types.Add(new PropertyDescriptor { Type = type, Name = name, Description = description, Category = _category, Display = display, Property = property, Form = form });
            return this;
    }
}
