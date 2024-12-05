using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.Tokens;

namespace Orchard.DynamicForms.Helpers {
    public static class TokenizerExtensions {
        public static IEnumerable<SelectListItem> Replace(this ITokenizer tokenizer, IEnumerable<SelectListItem> items, IDictionary<string, object> data, ReplaceOptions options) {
            return items.Select(item => new SelectListItem {
                Text = tokenizer.Replace(item.Text, data, options),
                Value = item.Value,
                Disabled = item.Disabled,
                Group = item.Group,
                Selected = item.Selected
            });
        }
    }
}
