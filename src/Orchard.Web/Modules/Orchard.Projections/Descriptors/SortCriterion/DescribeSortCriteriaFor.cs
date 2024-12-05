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

namespace Orchard.Projections.Descriptors.SortCriterion {
    public class DescribeSortCriterionFor {
        private readonly string _category;
        public DescribeSortCriterionFor(string category, LocalizedString name, LocalizedString description) {
            Types = new List<SortCriterionDescriptor>();
            _category = category;
            Name = name;
            Description = description;
        }
        public LocalizedString Name { get; private set; }
        public LocalizedString Description { get; private set; }
        public List<SortCriterionDescriptor> Types { get; private set; }
        public DescribeSortCriterionFor Element(string type, LocalizedString name, LocalizedString description, Action<SortCriterionContext> sort, Func<SortCriterionContext, LocalizedString> display, string form = null) {
            Types.Add(new SortCriterionDescriptor { Type = type, Name = name, Description = description, Category = _category, Sort = sort, Display = display, Form = form });
            return this;
    }
}
