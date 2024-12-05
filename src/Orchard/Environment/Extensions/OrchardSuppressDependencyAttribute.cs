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
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class OrchardSuppressDependencyAttribute : Attribute {
        public OrchardSuppressDependencyAttribute(string fullName) {
            FullName = fullName;
        }
        public string FullName { get; set; }
    }
}
