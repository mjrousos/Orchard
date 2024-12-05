using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Generic;
using Orchard.Mvc.Extensions;

namespace System.Web.Mvc {
    public static class ModelStateDictionaryExtensions {
        public static void AddModelErrors(this ModelStateDictionary modelStateDictionary, IDictionary<string, LocalizedString> validationErrors) {
            foreach (var error in validationErrors) {
                modelStateDictionary.AddModelError(error.Key, error.Value);
            }
        }
    }
}
