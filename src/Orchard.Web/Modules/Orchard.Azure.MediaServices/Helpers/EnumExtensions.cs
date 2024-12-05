using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;

namespace Orchard.Azure.MediaServices.Helpers {
    public static class EnumExtensions {      
        public static bool IsAny<T>(this T value, params T[] values) where T:struct {
            return values.Any(x => value.Equals(x));
        }
        public static bool IsNotAny<T>(this T value, params T[] values) where T:struct {
            return values.All(x => !value.Equals(x));
    }
}
