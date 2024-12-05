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

namespace Orchard.Modules.Models {
    public class DoghouseComparer : IComparer<string> {
        private readonly string _theDog;
        public DoghouseComparer(string theDog) {
            _theDog = theDog;
        }
        public int Compare(string x, string y) {
            if (x == null || y == null)
                return x == null && y == null ? 0 : (x == null ? -1 : 1);
            if (string.Equals(x, y, StringComparison.OrdinalIgnoreCase))
                return 0;
            if (string.Equals(x, _theDog, StringComparison.OrdinalIgnoreCase))
                return 1;
            if (string.Equals(y, _theDog, StringComparison.OrdinalIgnoreCase))
                return -1;
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    }
}
