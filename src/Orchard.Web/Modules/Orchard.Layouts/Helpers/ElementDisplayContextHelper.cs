using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Layouts.Framework.Display;

namespace Orchard.Layouts.Helpers {
    public static class ElementDisplayContextHelper {
        
        public static IDictionary<string, object> GetTokenData(this ElementDisplayingContext context) {
            var data = new Dictionary<string, object>();
            if (context.Content != null)
                data["Content"] = context.Content.ContentItem;
            return data;
        }
    }
}
