using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Orchard.Utility.Extensions {
    public static class NameValueCollectionExtensions {
        public static string ToQueryString(this NameValueCollection nameValues) =>
            string.Join(
                "&",
                (from string name in nameValues select string.Concat(name, "=", HttpUtility.UrlEncode(nameValues[name]))).ToArray());
    }
}
