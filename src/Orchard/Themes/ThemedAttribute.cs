using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Themes {
    public class ThemedAttribute : Attribute {
        public ThemedAttribute() {
            Enabled = true;
        }
        public ThemedAttribute(bool enabled) {
            Enabled = enabled;
        public bool Enabled { get; set; }
    }
}
