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
using System.Linq;

namespace Orchard.Commands {
    [AttributeUsage(AttributeTargets.Method)]
    public class OrchardSwitchesAttribute : Attribute {
        private readonly string _switches;
        public OrchardSwitchesAttribute(string switches) {
            _switches = switches;
        }
        public IEnumerable<string> Switches {
            get {
                return (_switches ?? "").Trim().Split(',').Select(s => s.Trim());
            }
    }
}
