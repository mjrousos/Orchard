using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.ContentManagement.Records {
    public static class Utility {
        public static bool IsPartRecord(Type type) {
            return type.IsSubclassOf(typeof(ContentPartRecord)) && !type.IsSubclassOf(typeof(ContentPartVersionRecord));
        }
        public static bool IsPartVersionRecord(Type type) {
            return type.IsSubclassOf(typeof(ContentPartVersionRecord));
    }
}
