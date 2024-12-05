using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Orchard.Layouts.Helpers {
    public static class JsonHelper {
        
        public static string ToJson(this object value, Formatting formatting = Formatting.None) {
            return value != null ? JObject.FromObject(value).ToString(formatting) : default(string);
        }
    }
}
