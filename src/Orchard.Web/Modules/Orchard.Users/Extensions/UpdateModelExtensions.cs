using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Localization;
using System.Collections.Generic;

namespace Orchard.ContentManagement {
    public static class UpdateModelExtensions {
        public static void AddModelErrors(this IUpdateModel updateModel, IDictionary<string, LocalizedString> validationErrors) {
            foreach (var error in validationErrors) {
                updateModel.AddModelError(error.Key, error.Value);
            }
        }
    }
}
