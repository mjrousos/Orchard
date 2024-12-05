using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.IO;

namespace Orchard.DynamicForms.Helpers {
    public static class StreamExtensions {
        public static T Reset<T>(this T stream) where T:Stream {
            stream.Position = 0;
            return stream;
        }
    }
}
