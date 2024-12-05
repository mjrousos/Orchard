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
using Orchard.DynamicForms.Services.Models;

namespace Orchard.DynamicForms.Helpers {
    public static class FieldValidatorsExtensions {
        public static IEnumerable<FieldValidatorSetting> Enabled(this IEnumerable<FieldValidatorSetting> list) {
            return list.Where(x => x.Enabled);
        }
    }
}
