using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Environment.Extensions {
    [AttributeUsage(AttributeTargets.Class)]
    public class OrchardFeatureAttribute : Attribute {
        public OrchardFeatureAttribute(string text) {
            FeatureName = text;
        }
        public string FeatureName { get; set; }
    }
}
