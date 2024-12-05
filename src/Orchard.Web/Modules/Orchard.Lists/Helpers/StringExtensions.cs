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

namespace Orchard.Lists.Helpers {
    public static class StringExtensions {
        /// <summary>
        /// Returns a comma joined string, but with the last comma replaced with "or". E.g. "Item 1, Item 2 or Item 3".
        /// </summary>
        public static LocalizedString ToOrString(this IEnumerable<string> names, Localizer T) {
            var list = names.ToList();
            if (!list.Any())
                return T("");
            if (list.Count == 1)
                return T(list.First());
            var allButLast = list.Take(list.Count - 1);
            var last = list.Last();
            return T("{0} or {1}", String.Join(", ", allButLast), last);
        }
    }
}
