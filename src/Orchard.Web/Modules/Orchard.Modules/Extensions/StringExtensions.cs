using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Utility.Extensions;

namespace Orchard.Modules.Extensions {
    public static class StringExtensions {
        public static string AsFeatureId(this string text, Func<string, LocalizedString> localize) {
            return string.IsNullOrEmpty(text)
                       ? ""
                       : string.Format(localize("{0} feature").ToString(), text).HtmlClassify();
        }
    }
}
