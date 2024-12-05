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

namespace Orchard.Rules.Models {
    public class DescribeActionFor {
        private readonly string _category;
        public DescribeActionFor(string category, LocalizedString name, LocalizedString description) {
            Types = new List<ActionDescriptor>();
            _category = category;
            Name = name;
            Description = description;
        }
        public LocalizedString Name { get; private set; }
        public LocalizedString Description { get; private set; }
        public List<ActionDescriptor> Types { get; private set; }
        public DescribeActionFor Element(string type, LocalizedString name, LocalizedString description, Func<ActionContext, bool> action, Func<ActionContext, LocalizedString> display, string form = null) {
            Types.Add(new ActionDescriptor { Type = type, Name = name, Description = description, Category = _category, Action = action, Display = display, Form = form });
            return this;
    }
}
