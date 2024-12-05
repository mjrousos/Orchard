using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Orchard.Utility.Extensions {
    public static class ReadOnlyCollectionExtensions {
        public static IList<T> ToReadOnlyCollection<T>(this IEnumerable<T> enumerable) {
            return new ReadOnlyCollection<T>(enumerable.ToList());
        }
    }
}
